
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        //public Random random = new Random();
        //private bool IsCursed = false;
        public int PrisonerStatus = 0;
        public int RestCounter = 0;
        public int Y { get; set; }
        public int X { get; set; }
        public string LocationId { get; set; }
        public NPC? MushroomMan { get; set; }
        public Armor? Armor { get; set; }
        public Weapon? Weapon { get; set; }
        public int Modifier { get; set; } = 0;
        public int Sanity { get; set; } = 100;
        public int Charisma { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Athletics { get; set; } = 0;
        public int Perception { get; set; } = 0;
        public int XP { get; set; } = 0;
        public int MaxHP { get; set; } = 100;
        public int PlayerLevel { get; set; } = 1;
        public int PlotOneLvl { get; set; } = 1;
        public int PlotTwoLvl { get; set; } = 1;
        public int PlotThreeLvl { get; set; } = 1;
        public bool IsPlaying { get; set; } = true;
        public int Mana { get; set; } = 3;
        public int Gold { get; set; }
        public Player(string name, string description) : base()
        {
            Name = name;
            Description = description;
            ArmorClass = 8;
            Health = 100;
            Gold = 10;
            Dexterity = 0;
            Athletics = 0;
            Perception = 0;
            Y = 0;
            X = 0;
            LocationId = "00";
            Mana = 3;

        }
        private readonly int minAttack = 8;
        private readonly int maxAttack = 12;
        private readonly int minDamage = 8;
        private readonly int maxDamage = 12;
        public void PrintPlayerDetails()
        {
            Console.WriteLine();
            Console.WriteLine($"Player: {Name} - Level: {PlayerLevel}({XP}xp)");
            Console.WriteLine($"Location: {LocationId} - Gold: {Gold}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Current Health: {Health} - Maximum Health: {MaxHP}");
            Console.WriteLine($"Mana: {Mana} - Sanity: {Sanity}");
            Console.WriteLine($"Skills:");
            if (Charisma > 1) Console.Write($"Charisma: {Charisma}");
            if (Athletics > 1) Console.Write($"Athletics: {Athletics}");
            if (Perception > 1) Console.Write($"Perception: {Perception}");
            if (Dexterity > 1) Console.Write($"Charisma: {Dexterity}");
            Console.WriteLine($"AC: {ArmorClass} - Modifier: {Modifier}");
            if(Armor != null)
            {
                Console.WriteLine($"Armor Current Equipped: {Armor.Name} - AC Bonus: {Armor.AC}");
            } else
            {
                Console.WriteLine("No armor currently equipped");
            }
            if (Weapon != null)
            {
                Console.WriteLine($"Armor Current Equipped: {Weapon.Name} - Attack Bonus: {Weapon.Boost}");
            }
            else
            {
                Console.WriteLine("No weapon currently equipped");
            }
        }
        public void NavCase(string decision, Chamber currentChamber)
        {
            switch (decision) {
                case "n":
                    if (currentChamber.NorthPassage)
                    {
                        Y += 1;
                        Console.WriteLine($"{Y}{X}");
                        break;
                    }
                    else
                    {

                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "s":
                    if (currentChamber.SouthPassage)
                    {
                        Y -= 1;
                        Console.WriteLine($"{Y}{X}");

                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "w":
                    if (currentChamber.WestPassage)
                    {
                        X -= 1;
                        Console.WriteLine($"{Y}{X}");
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                case "e":
                    if (currentChamber.EastPassage)
                    {
                        X += 1;
                        Console.WriteLine($"{Y}{X}");
                        break;
                    }
                    else
                    {
                        Console.Write("You can't go this way\n");
                        break;
                    }
                default:
                    break;
            }

        }
        public void MovePlayer(string decision, Dungeon dungeon)
        {
            Chamber previousChamber = dungeon.ExploredChambers[LocationId];
            string locationRef = LocationId;
            NavCase(decision, previousChamber);
            LocationId = $"{Y}{X}";

            if(dungeon.ExploredChambers.ContainsKey(LocationId))
            {
                Chamber currentChamber = dungeon.ExploredChambers[LocationId];
                Console.WriteLine("You've already explored this room");
                Console.WriteLine("Would you like to view the description again?\n1) Yes\n2) No");
                int viewDecision = Utility.PrintMenu(2);
                if(viewDecision == 1)
                {
                    currentChamber.DisplayDescription();
                } else
                {
                    return;
                }
            } else
            {
                //bool trigger = false;
                //PlotTrigger(trigger, dungeon);
                //if (!trigger)
                //{
                    Chamber newChamber = dungeon.GenerateChamber(LocationId);
                    switch (decision)
                    {
                        case "n":
                            newChamber.SouthPassage = true;
                            break;
                        case "s":
                            newChamber.NorthPassage = true;
                            break;
                        case "e":
                            newChamber.WestPassage = true;
                            break;
                        case "w":
                            newChamber.EastPassage = true;
                            break;
                    }
                    Console.WriteLine($"E {newChamber.EastPassage},W {newChamber.WestPassage},N {newChamber.NorthPassage},S {newChamber.SouthPassage}");
                    newChamber.DisplayDescription();
                    RestCounter += 1;

                newChamber.MasterEventsTree(this);
                Console.WriteLine("The room is safe. What would you like to do next?");
                Console.WriteLine("1) Search Room\n2) Rest Here"); 
                dungeon.ExploredChambers[LocationId] = newChamber;
                
                //}

            }
        }
        public void AddToInventory(Item item)
        {
            bool InventoryFull = true;
            for(int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == null)
                {
                    Inventory[i] = item;
                    InventoryFull = false;
                }
            }
            if (InventoryFull) 
            {
                Console.WriteLine("Inventory is currently full, please select an item to discard");
                PrintInventory();
                int decision = Utility.PrintMenu(Inventory.Length) - 1;
                Console.WriteLine($"You have selected {Inventory[decision].Name} to discard. Continue? Y/N");
                string discardDecision = Console.ReadLine().ToLower();
                if (discardDecision == "y")
                {
                    Inventory[decision] = item;
                    Console.WriteLine($"{item.Name} has been added to your inventory");
                }
                else
                {
                    Console.WriteLine("Item not added to inventory");
                }
            }
        }
        public void MonsterFight(Monster monster)
        {
            do
            {
                Console.WriteLine("What attack action do you wish to take?");
                Console.WriteLine("1) Attack 2) Mana Blast 3) Dodge");
                int decision = Utility.PrintMenu(2);
                if (decision == 1) {
                    Attack(monster);
                    monster.Attack(this);
                }
                else if (decision == 2)
                {
                    if (Mana <= 0)
                    {
                        Console.WriteLine("You have no mana to use a mana blast");
                        continue;
                    } else
                    {
                        int manaDamage = PlayerLevel * 10;
                        Console.WriteLine($"You have used a mana blast for {manaDamage} points of damage");
                        monster.Health -= manaDamage;
                        if (monster.Health <= 0)
                        {
                            Console.WriteLine($"You killed the {monster.Name}");
                        }
                        Mana -= 1;

                    }
                    monster.Attack(this);
                } else if (decision == 3)
                {
                    monster.Attack(this);
                    Console.WriteLine("You have attempt to dodge the attack");
                }
                PlayerDeathCheck();
            } while (monster.Health > 0);
            UseAmor();
            if (RestCounter < 5)
            {
                GainXp(monster);
                XpLevelUp();
            }
            RestCounter += 1;
        }
        public void UseWeapon()
        {
            if (Weapon != null)
            {
                Weapon.Durability -= 1;
                if (Weapon.Durability <= 0)
                {
                    Console.WriteLine($"Weapon is broken and cannot be used.");
                    Weapon = null;
                }
            }
            else
            {
                Console.WriteLine("You don't have a weapon to use.");
            }
        }
        public void UseAmor()
        {
            if (Armor != null)
            {
                Armor.Durability -= 1;
                if (Weapon.Durability <= 0)
                {
                    Console.WriteLine($"Weapon is broken and cannot be used.");
                    ArmorClass -= Armor.AC;
                    Armor = null;
                }
            }
        }
        public override void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = Utility.GetRandomIndex(minAttack, maxAttack) + Modifier;
                int damage = Utility.GetRandomIndex(minDamage, maxDamage) + Modifier;
                if (Weapon != null)
                {
                    attack += Weapon.Boost;
                    damage += Weapon.Boost;
                }
                if (attack > targetCharacter.ArmorClass)
                {
                    UseWeapon();
                    Console.WriteLine($"You attacked the {targetCharacter.Name} and hit for {damage} damage");
                    targetCharacter.Health -= damage;
                    if (targetCharacter.Health <= 0)
                    {
                        Console.WriteLine($"You killed the {targetCharacter.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"You attacked but missed");
                }
            }
        }
        //public void PlotTrigger(bool trigger, Dungeon dungeon)
        //{

        //    if(X > 5 && Y < 5 && PlotOneLvl == 1)
        //    {
        //        Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotOneLvl, LocationId);
        //        PlotOneLvl = 2;
        //        trigger = true;
        //    }else if(X > 10 && Y < 5 && PlotOneLvl == 2)
        //    {
        //        Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotOneLvl, LocationId);
        //        PlotOneLvl = 3;
        //        trigger = true;
        //    }
        //    else if(X < -5 && Y < 5 && PlotTwoLvl == 1)
        //    {
        //        Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotTwoLvl, LocationId);
        //        PlotTwoLvl = 2;
        //        trigger = true;
        //    }
        //    else if (X < -10 && Y < 5 && PlotTwoLvl == 2)
        //    {
        //        Battlefield PlotTwoBattle = dungeon.GeneratePlotOneBattlefield(PlotTwoLvl, LocationId);
        //        PlotTwoLvl = 3;
        //        trigger = true;
        //    }
        //    else if (Y > 5 && PlotThreeLvl == 1)
        //    {
        //        Battlefield PlotTwoBattle = dungeon.GeneratePlotOneBattlefield(PlotThreeLvl, LocationId);
        //        PlotThreeLvl = 2;
        //        trigger = true;
        //    }
        //    else if(Y > 10 && PlotThreeLvl == 2)
        //    {
        //        Battlefield PlotThreeBattle = dungeon.GeneratePlotOneBattlefield(PlotThreeLvl, LocationId);
        //        PlotThreeLvl = 3;
        //        trigger = true;
        //    }
        //}
        public void PlayerDeathCheck()
        {
            if (Health <= 0)
            {
                if(PrisonerStatus == 1)
                {
                    Console.WriteLine("Your vision grows dim as you feel the life begin to drain from you.");
                    Console.WriteLine("Then you see a familiar face, that of the prisoner you released");
                    Console.WriteLine("They burst into blinding white light both vanquishing your enemies as well and sending a healing surge through your body");
                    Health += 50;
                }
                Console.WriteLine("You have died");
                IsPlaying = false;
            }
        }
        public void ApplySkillPoint() 
        {
            bool skillApplied = false;
            while (!skillApplied) {
                string skill = Console.ReadLine().Trim().ToLower();
                switch (skill)
                {
                    case "athletics":
                    case "ath":
                        Athletics += 1;
                        skillApplied = true;
                        break;
                    case "perception":
                    case "per":
                        Perception += 1;
                        skillApplied = true;
                        break;
                    case "dexterity":
                    case "dex":
                        Dexterity += 1;
                        skillApplied = true;
                        break;
                    default:
                        Console.WriteLine("Invalid skill");
                        break;
                }
            }
        }
        public void GainXp(Monster monster)
        {
            int xp = monster.XP;
            XP += xp;
        }
        public void IncreaseModifier()
        {
            Console.WriteLine("You gain an increase to your overall modifier.");
            Modifier += 1;
        }
        public void PointIncreaseWrapper()
        {
            Console.WriteLine("You may spend another skill point on Athletics, Perception, or Dexterity");
            Console.WriteLine("Please enter which skill you choose first");
            ApplySkillPoint();
        }
        public void GainHP()
        {

        }
        public void XpLevelUp()
        {
            Console.WriteLine("Your experience has granted you a boon.");
            if (XP > 500 && PlayerLevel == 0)
            {
                GainHP();
                PlayerLevel = 1;
            }
            else if (XP > 1000 && PlayerLevel == 1)
            {
                PointIncreaseWrapper();
                PlayerLevel = 2;
            }
            else if (XP > 1500 && PlayerLevel == 2)
            {
                IncreaseModifier();
                PlayerLevel = 3;
            }
            else if (XP > 2000 & PlayerLevel == 3)
            {
                GainHP();
                PlayerLevel = 4;
            }
            else if (XP > 2500 && PlayerLevel == 4)
            {
                PointIncreaseWrapper();
                PlayerLevel = 5;
            }
            else if (XP > 3000 && PlayerLevel == 5)
            {
                IncreaseModifier();
                PlayerLevel = 6;
            } else if(XP > 3500 && PlayerLevel == 6)
            {
                GainHP();
                PlayerLevel = 7;
            } else if(XP > 4000 && PlayerLevel == 7)
            {
                PointIncreaseWrapper();
                PlayerLevel = 8;
            } else if(XP > 4500 && PlayerLevel == 8)
            {
                IncreaseModifier();
                PlayerLevel = 9;
            } else if(XP > 5000 && PlayerLevel == 9)
            {
                GainHP(); // Should be something bigger 
                PlayerLevel = 10;
            }
        }
        //public void Flee()
        //{

        //}

        //public void CurseTracker()
        //{

        //}
    }
}
