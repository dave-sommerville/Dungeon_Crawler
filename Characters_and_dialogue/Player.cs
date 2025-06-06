using Dungeon_Crawler.Items;
using Dungeon_Crawler.Items.Potions;

namespace Dungeon_Crawler.Characters_and_dialogue
{
    public class Player : Character
    {
        //  STATUS TRACKERS
        public int PrisonerStatus = 0;
        public int RestCounter = 0;
        public static bool PositiveInteraction = false;
        public bool IsPlaying { get; set; } = true;
        //  LOCATION
        public int Y { get; set; }
        public int X { get; set; }
        public string LocationId { get; set; }
        //  EQIPMENT
        public Armor? Armor { get; set; }
        public Weapon? Weapon { get; set; }
        //  PERSONAL STATS 
        public int XP { get; set; } = 0;
        public int PlayerLevel { get; set; } = 1;
        public int Modifier { get; set; } = 0;
        public int Sanity { get; set; } = 100;
        public int Charisma { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Athletics { get; set; } = 0;
        public int Perception { get; set; } = 0;
        //  RESOURES
        public int Mana { get; set; } = 3;
        public int Gold { get; set; }
        public int MaxHP { get; set; } = 100;
        //  PLOT PROGRESSION
        public int PlotOneLvl { get; set; } = 1;
        public int PlotTwoLvl { get; set; } = 1;
        public int PlotThreeLvl { get; set; } = 1;
        public NPC? MushroomMan { get; set; }
        public Item? GreyStoneSpire { get; set; }
        //  ATTACK RANGES 
        private readonly int minAttack = 8;
        private readonly int maxAttack = 12;
        private readonly int minDamage = 8;
        private readonly int maxDamage = 12;
        public Player(string name, string description) : base()
        {
            Name = name;
            Description = description;
            ArmorClass = 8;
            Health = 1000;
            Gold = 10;
            Dexterity = 0;
            Athletics = 0;
            Perception = 0;
            Y = 0;
            X = 0;
            LocationId = "00";
            Mana = 3;
            Inventory[0] = new Armor();
            Inventory[1] = new Weapon();
            Inventory[2] = new Potion();
        }
        public void PrintPlayerDetails()
        {
            Console.WriteLine();
            Utility.Print($"Player: {Name} - Level: {PlayerLevel}({XP}xp)");
            Utility.Print($"Location: {LocationId} - Gold: {Gold}");
            Utility.Print($"Description: {Description}");
            Utility.Print($"Current Health: {Health} - Maximum Health: {MaxHP}");
            Utility.Print($"Mana: {Mana} - Sanity: {Sanity} - Exhaustion: {RestCounter}");
            Utility.Print($"Skills:");
            if (Charisma > 1) Utility.Print($"Charisma: {Charisma}");
            if (Athletics > 1) Utility.Print($"Athletics: {Athletics}");
            if (Perception > 1) Utility.Print($"Perception: {Perception}");
            if (Dexterity > 1) Utility.Print($"Charisma: {Dexterity}");
            Utility.Print($"AC: {ArmorClass} - Modifier: {Modifier}");
            Utility.Print($"Equipment:");
            if (Armor != null)
            {
                Utility.Print($"Armor: {Armor.Name} - AC Bonus: {Armor.AC}");
            }
            if (Weapon != null)
            {
                Utility.Print($"Weapon: {Weapon.Name} - Attack Bonus: {Weapon.Boost}");
            }
            if (GreyStoneSpire != null)
            {
                Utility.Print($"Artifact: Grey Stone Spire - Details: None");
            }
        }
        public void NavCase(string decision, Chamber currentChamber)
        {
            switch (decision)
            {
                case "n":
                    if (currentChamber.NorthPassage)
                    {
                        Y += 1;
                        Utility.Print($"{Y}{X}");
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
                        Utility.Print($"{Y}{X}");

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
                        Utility.Print($"{Y}{X}");
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
                        Utility.Print($"{Y}{X}");
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

            if (dungeon.ExploredChambers.ContainsKey(LocationId))
            {
                Chamber currentChamber = dungeon.ExploredChambers[LocationId];
                Utility.Print("You've already explored this room");
                Utility.Print("Would you like to view the description again?\n1) Yes\n2) No");
                string viewDecision = Utility.Read();
                if (viewDecision == "n")
                {
                    currentChamber.DisplayDescription();
                }
                else
                {
                    return;
                }
            }
            else
            {
                int plotTrigger = PlotTrigger(dungeon);
                if (plotTrigger == -1)
                {
                    Chamber newChamber = dungeon.GenerateChamber(LocationId);
                    newChamber.ReturnPassages(decision);
                    Utility.Print($"E {newChamber.EastPassage},W {newChamber.WestPassage},N {newChamber.NorthPassage},S {newChamber.SouthPassage}");
                    newChamber.DisplayDescription();
                    RestCounter += 1;
                    newChamber.MasterEventsTree(this);
                    if (IsPlaying) {
                        Utility.Print("The room is safe. What would you like to do next?");
                        Utility.Print("1) Search Room\n2) Rest Here");
                        dungeon.ExploredChambers[LocationId] = newChamber;
                    }
                }
                else
                {
                    Utility.Print("Boss fight");
                    Utility.Print($"{plotTrigger}");
                    BossFight(dungeon, plotTrigger);
                }
            }
        }
        public void AddToInventory(Item item)
        {
            bool inventoryFull = true;
            bool itemAdded = false;

            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == null && itemAdded == false)
                {
                    Inventory[i] = item;
                    itemAdded = true;
                }
                if (Inventory[i] == null)
                {
                    inventoryFull = false;
                }
            }
            if (inventoryFull)
            {
                for (int i = 0; i < Inventory.Length; i++) {
                    Utility.Print("Inventory is currently full, please select an item to discard");
                    PrintInventory();
                    int decision = Utility.PrintMenu(Inventory.Length) - 1;
                    Utility.Print($"You have selected {Inventory[decision].Name} to discard. Continue? Y/N");
                    bool validDecision = false;
                    do
                    {
                        string discardDecision = Utility.Read();
                        if (discardDecision == "y")
                        {
                            Inventory[decision] = item;
                            Utility.Print($"{item.Name} has been added to your inventory");
                        }
                        else if (discardDecision == "n")
                        {
                            Utility.Print("Item not added to inventory");
                            validDecision = true;
                        }
                        else
                        {
                            Utility.Print("Please enter a valid choice");
                        }
                    } while (validDecision);
                }
            }
        }
        public void PrintInventory()
        {
            Utility.Print("Current Inventory:");
            for (int i = 0; i < Inventory.Length; i++)
            {
                bool inventoryEmpty = true;
                if (Inventory[i] != null)
                {
                    Utility.Print($"{i + 1}) {Inventory[i].Name}");
                    inventoryEmpty = false;
                }
                if(inventoryEmpty)
                {
                    Utility.Print($"{i + 1}) Inventory Slot Empty");
                }
            }
        }
        public void UseItemOption()
        {
            Console.WriteLine();
            Utility.Print("Use item (y/n)");
            bool validChoice = false;
            do
            {
                string choice = Utility.Read();
                if (choice == "y")
                {
                    PrintInventory();
                    UseInventoryItem();
                    validChoice = true;
                }
                else if (choice == "n")
                {
                    validChoice = true;
                }
                else
                {
                    Utility.Print("Please enter a valid choice");
                }
            } while (!validChoice);
        }
        public void UseInventoryItem()
        {
            bool itemFound = false;
            do
            {
                Utility.Print("Please select an item to use");
                Utility.Print("Enter 0 to return");
                int choice = Utility.PrintMenu(Inventory.Length);
                choice--;
                if (choice == -1)
                {
                    itemFound = true;
                    break;
                } else if (Inventory[choice] != null)
                {
                    Inventory[choice].EquipItem(this);
                    Inventory[choice] = null;
                }
                else
                {
                    Utility.Print("That inventory slot is empty");
                }
            } while (!itemFound);
        }
        public void MonsterFight(Monster monster)
        {
            do
            {
                FightMenu(monster);
                PlayerDeathCheck();
            } while (monster.Health > 0 && IsPlaying);
            UseAmor();
            if (RestCounter < 5)
            {
                GainXp(monster);
                XpLevelUp();
            }
            RestCounter += 1;
        }
        public void BossFight(Dungeon dungeon, int plotIndex)
        {
            Boss boss = Boss.GetPlotBoss(plotIndex);
            Chamber battlefield = dungeon.GenerateChamber(LocationId);
            battlefield.Monster = boss;
            dungeon.ExploredChambers[LocationId] = battlefield;
            boss.InteractionInProgress = true;
            boss.Dialogue.Node(boss);
            do
            {
                FightMenu(boss);
                PlayerDeathCheck();
                boss.BossDeathCheck();
            } while (boss.Health > 0 && IsPlaying);
            UseAmor();
            if (RestCounter < 5)
            {
                GainXp(boss);
                XpLevelUp();
            }
            RestCounter += 1; // Chamber will already have loot, if anything maybe I could leave the bosses "Relics" or something 
        }
        public void FightMenu(Monster monster)
        {
            Utility.Print("What attack action do you wish to take?");
            Utility.Print("1) Attack 2) Mana Blast 3) Dodge 4) Use Item");
            int decision = Utility.PrintMenu(4);
            if (decision == 1)
            {
                Attack(monster);
                monster.Attack(this);
            }
            else if (decision == 2)
            {
                if (Mana <= 0)
                {
                    Utility.Print("You have no mana to use a mana blast");
                }
                else
                {
                    int manaDamage = PlayerLevel * 10;
                    Utility.Print($"You have used a mana blast for {manaDamage} points of damage");
                    monster.Health -= manaDamage;
                    if (monster.Health <= 0)
                    {
                        Utility.Print($"You killed the {monster.Name}");
                    }
                    Mana -= 1;
                    monster.Attack(this);
                }
            }
            else if (decision == 3)
            {
                IsDodging = true;
                monster.Attack(this);
                Utility.Print("You have attempted to dodge the attack");
            }
            else if (decision == 4)
            {
                PrintInventory();
                UseInventoryItem();
            }
        }
        public void UseWeapon()
        {
            if (Weapon != null)
            {
                Weapon.Durability -= 1;
                if (Weapon.Durability <= 0)
                {
                    Utility.Print($"Weapon is broken and cannot be used.");
                    Weapon = null;
                }
            }
        }
        public void UseAmor()
        {
            if (Armor != null)
            {
                Armor.Durability -= 1;
                if (Armor.Durability <= 0)
                {
                    Utility.Print($"Weapon is broken and cannot be used.");
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
                    Utility.Print($"You attacked the {targetCharacter.Name} and hit for {damage} damage");
                    targetCharacter.Health -= damage;
                    if (targetCharacter.Health <= 0)
                    {
                        Utility.Print($"You killed the {targetCharacter.Name}");
                    }
                }
                else
                {
                    Utility.Print($"You attacked but missed");
                }
            }
        }
        public int PlotTrigger(Dungeon dungeon)
        {
            int plotIndex = -1; // Need to add player level to checks or else this'll get out of hand
            if (X > 5 && Y < 5 && PlotOneLvl == 1)
            {
                PlotOneLvl = 2;
                plotIndex = 1;
            }
            else if (X > 10 && Y < 5 && PlotOneLvl == 2)
            {
                PlotOneLvl = 3;
                plotIndex = 2;
            }
            else if (X < -5 && Y < 5 && PlotTwoLvl == 1)
            {
                PlotTwoLvl = 2;
                plotIndex = 3;
            }
            else if (X < -10 && Y < 5 && PlotTwoLvl == 2)
            {
                PlotTwoLvl = 3;
                plotIndex = 4;
            }
            else if (Y > 5 && PlotThreeLvl == 1)
            {
                PlotThreeLvl = 2;
                plotIndex = 5;
            }
            else if (Y > 10 && PlotThreeLvl == 2)
            {
                PlotThreeLvl = 3;
                plotIndex = 6;
            }
            return plotIndex;
        }
        public void PlayerDeathCheck()
        {
            if (Sanity > 0)
            {
                if (Health <= 0)
                {
                    if (PrisonerStatus == 1)
                    {
                        Utility.Print("Your vision grows dim as you feel the life begin to drain from you.");
                        Utility.Print("Then you see a familiar face, that of the prisoner you released");
                        Utility.Print("They burst into blinding white light both vanquishing your enemies as well and sending a healing surge through your body");
                        PrisonerStatus = 2;
                        Health += 50;
                    }
                    else
                    {
                        Utility.Print("You have died");
                        GameOver();
                    }
                }
            }
            else
            {
                Utility.Print("You have lost grip on reality, you can no longer hold yourself together.");
                GameOver();
            }
        }
        public void ApplySkillPoint()
        {
            bool skillApplied = false;
            while (!skillApplied)
            {
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
                        Utility.Print("Invalid skill");
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
            Utility.Print("You gain an increase to your overall modifier.");
            Modifier += 1;
        }
        public void PointIncreaseWrapper()
        {
            Utility.Print("You may spend another skill point on Athletics, Perception, or Dexterity");
            Utility.Print("Please enter which skill you choose first");
            ApplySkillPoint();
        }
        public void GainHP()
        {
            Health += 15;
            MaxHP += 15;
        }
        public void XpLevelUp()
        {
            if (XP > 500 && PlayerLevel == 1)
            {
                Utility.Print("You have gained a level!");
                GainHP();
                PlayerLevel = 2;
            }
            else if (XP > 1000 && PlayerLevel == 2)
            {
                Utility.Print("You have gained a level!");
                PointIncreaseWrapper();
                PlayerLevel = 3;
            }
            else if (XP > 1500 && PlayerLevel == 3)
            {
                Utility.Print("You have gained a level!");
                IncreaseModifier();
                PlayerLevel = 4;
            }
            else if (XP > 2000 & PlayerLevel == 4)
            {
                Utility.Print("You have gained a level!");
                GainHP();
                PlayerLevel = 5;
            }
            else if (XP > 2500 && PlayerLevel == 5)
            {
                Utility.Print("You have gained a level!");
                PointIncreaseWrapper();
                PlayerLevel = 6;
            }
            else if (XP > 3000 && PlayerLevel == 6)
            {
                Utility.Print("You have gained a level!");
                IncreaseModifier();
                PlayerLevel = 7;
            }
            else if (XP > 3500 && PlayerLevel == 7)
            {
                Utility.Print("You have gained a level!");
                GainHP();
                PlayerLevel = 8;
            }
            else if (XP > 4000 && PlayerLevel == 8)
            {
                Utility.Print("You have gained a level!");
                PointIncreaseWrapper();
                PlayerLevel = 9;
            }
            else if (XP > 4500 && PlayerLevel == 9)
            {
                IncreaseModifier();
                PlayerLevel = 10;
                Utility.Print("You have achieved the highest level possible and completed this stage of the dungeon!");
                GameOver();
            }
        }
        public void GameOver()
        {
            Utility.Print("Game Over");
            Utility.Print("Would you like to save your game to a file? (y/n)");
            string decision = Utility.Read();
            if (decision == "y")
            {
                File.WriteAllLines("game-history.txt", Utility.GameHistory);
                Console.WriteLine("Your progress has been saved to file 'game-history.txt'");
            }
            IsPlaying = false;
        }
        public static int CharismaCheck(int length)
        {
            int choice = Utility.PrintMenu(length);
            if (choice == 1)
            {
                PositiveInteraction = true;
            }
            return choice;
        }
        public void ProcessCharisma()
        {
            if(PositiveInteraction)
            {
                Charisma += 1;
                PositiveInteraction = false;
            }
        }
    }
}
