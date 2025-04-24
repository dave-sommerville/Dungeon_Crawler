
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public Random random = new Random();
        //private bool IsCursed = false;
        public bool PrisonerReleased = false;
        private int RestCounter = 0;
        public int Y { get; set; }
        public int X { get; set; }
        public string LocationId { get; set; }
        public Armor? Armor { get; set; }
        public Weapon? Weapon { get; set; }
        public int Modifier { get; set; } = 0;
        public int Sanity { get; set; } = 100;
        public int Dexterity { get; set; } = 0;
        public int Athletics { get; set; } = 0;
        public int Perception { get; set; } = 0;
        public int XP { get; set; } = 0;
        public int PlayerLevel { get; set; } = 1;
        public int PlotOneLvl { get; set; } = 1;
        public int PlotTwoLvl { get; set; } = 1;
        public int PlotThreeLvl { get; set; } = 1;
        public bool IsPlaying { get; set; } = true;
        public int Mana { get; set; } = 3;
        public int Gold { get; set; }
        public Item[] Inventory { get; set; } = new Item[10];
        public Player(string name, string description) : base(name, description)
        {
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
        public static int PrintMenu(int options)
        {
            int intDecision;
            bool isValid;
            do
            {
                string decision = Console.ReadLine();
                isValid = int.TryParse(decision, out intDecision) && intDecision >= 1 && intDecision <= options;
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (!isValid);
            return intDecision;
        }
        public void PrintPlayerDetails() // Needs expanding 
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"AC: {ArmorClass}\nHP: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine("Inventory:");

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
                int viewDesicion = PrintMenu(2);
                if(viewDesicion == 1)
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
                int decision = PrintMenu(Inventory.Length) - 1;
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
        public void PrintInventory()
        {
            Console.WriteLine($"{Name}'s Inventory:");
            foreach(Item item in Inventory)
            {
                if (item != null)
                {
                    Console.WriteLine($"- {item.Name}");
                } else
                {
                    Console.WriteLine("Empty Slot");
                }
            }
        }
        public void MonsterFight(Monster monster)
        {
            do
            {
                Console.WriteLine("What attack action do you wish to take?");
                Console.WriteLine("1) Attack 2) Mana Blast");
                int decision = PrintMenu(2);
                if (decision == 1) {
                    Attack(monster);
                } else if (decision == 2)
                {
                    Console.WriteLine("You have used a mana blast");
                }
                monster.Attack(this);
                PlayerDeathCheck();
            } while (monster.Health > 0);
            GainXp(monster);
            XpLevelUp();
            RestCounter += 1;
        }
        public void FightActions(Monster monster)
        {

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
        public override void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = random.Next(minAttack, maxAttack) + Modifier;
                int damage = random.Next(minDamage, maxDamage) + Modifier;
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
        public void PlotTrigger(bool trigger, Dungeon dungeon)
        {

            if(X > 5 && Y < 5 && PlotOneLvl == 1)
            {
                Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotOneLvl, LocationId);
                PlotOneLvl = 2;
                trigger = true;
            }else if(X > 10 && Y < 5 && PlotOneLvl == 2)
            {
                Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotOneLvl, LocationId);
                PlotOneLvl = 3;
                trigger = true;
            }
            else if(X < -5 && Y < 5 && PlotTwoLvl == 1)
            {
                Battlefield PlotOneBattle = dungeon.GeneratePlotOneBattlefield(PlotTwoLvl, LocationId);
                PlotTwoLvl = 2;
                trigger = true;
            }
            else if (X < -10 && Y < 5 && PlotTwoLvl == 2)
            {
                Battlefield PlotTwoBattle = dungeon.GeneratePlotOneBattlefield(PlotTwoLvl, LocationId);
                PlotTwoLvl = 3;
                trigger = true;
            }
            else if (Y > 5 && PlotThreeLvl == 1)
            {
                Battlefield PlotTwoBattle = dungeon.GeneratePlotOneBattlefield(PlotThreeLvl, LocationId);
                PlotThreeLvl = 2;
                trigger = true;
            }
            else if(Y > 10 && PlotThreeLvl == 2)
            {
                Battlefield PlotThreeBattle = dungeon.GeneratePlotOneBattlefield(PlotThreeLvl, LocationId);
                PlotThreeLvl = 3;
                trigger = true;
            }
        }
        //public void Flee()
        //{

        //}
        public void PlayerDeathCheck()
        {
            if (Health <= 0)
            {
                if(PrisonerReleased)
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
            string skill = Console.ReadLine().Trim().ToLower();
            switch (skill)
            {
                case "athletics":
                case "ath":
                    Athletics += 1;
                    break;
                case "perception":
                case "per":
                    Perception += 1;
                    break;
                case "dexterity":
                case "dex":
                    Dexterity += 1;
                    break;
                default:
                    Console.WriteLine("Invalid skill");
                    break;
            }
        }
        public void GainXp(Monster monster)
        {
            int xp = monster.XP;
            XP += xp;
        }
        public void GainHP()
        {

        }
        public void XpLevelUp()
        {
            // Modifier, HP, Skill Point, HP, Mana, HP, Modifier, HP, Skill Point, HP(something bigger)
            //if (XP >= 500 && Level < 1) { Level = 1; IncreaseHP(10); }
            //if (XP >= 1000 && Level < 2) { Level = 2; IncreaseHP(10); IncreaseSkillPoints(1); }
            // etc.

            if (XP > 500)
            {
                PlayerLevel = 1;
            }
            else if (XP > 1000)
            {
                PlayerLevel = 2;
            }
            else if (XP > 1500)
            {
                PlayerLevel = 3;
            }
            else if (XP > 2000)
            {
                PlayerLevel = 4;
            }
            else if (XP > 2500)
            {
                PlayerLevel = 5;
            }
            else if (XP > 3000)
            {
                PlayerLevel = 6;
            } else if(XP > 3500)
            {
                PlayerLevel = 7;
            } else if(XP > 4000)
            {
                PlayerLevel = 8;
            } else if(XP > 4500)
            {
                PlayerLevel = 9;
            } else if(XP > 5000)
            {
                PlayerLevel = 10;
            }
        }
        //public void CurseTracker()
        //{

        //}
    }
}
