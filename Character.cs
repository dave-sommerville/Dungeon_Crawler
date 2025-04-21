using System.Runtime.InteropServices.Marshalling;

namespace Dungeon_Crawler
{
    public class Character
    {
        private readonly int _nextId;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }

        public Character(string name, string description)
        {
            Id = _nextId++;
            Name = name;
            Description = description;
            ArmorClass = 0;
            Health = 0;
        }
        public virtual void Attack(Character targetCharacter)
        {
            if (Health <= 0)
            {
                return;
            }
            else
            {
                int attack = 5;
                if (attack > targetCharacter.ArmorClass)
                {
                    Console.WriteLine($"{Name} attacked {targetCharacter.Name} and hit for {attack} damage");
                    targetCharacter.Health -= attack; // Shoud check target's health 
                }
                else
                {
                    Console.WriteLine($"{Name} attacked but missed");
                }
            }
        }
    }
}
