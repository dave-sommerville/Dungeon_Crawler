namespace Dungeon_Crawler
{
    public class Spell
    {
        public void Stun(Character targetCharacter)
        {
            if (targetCharacter.IsStunned)
            {
                Console.WriteLine($"{targetCharacter.Name} is already stunned.");
            }
            else
            {
                targetCharacter.IsStunned = true;
                Console.WriteLine($"{targetCharacter.Name} has been stunned!");
            }
        }
        public void Blur(Character targetCharacter)
        {
            if (targetCharacter.IsDodging)
            {
                Console.WriteLine($"{targetCharacter.Name} is already dodging.");
            }
            else
            {
                targetCharacter.IsDodging = true;
                Console.WriteLine($"{targetCharacter.Name} is now dodging!");
            }
        }
        public void Heal(Character targetCharacter)
        {
            if (targetCharacter.Health <= 0)
            {
                Console.WriteLine($"{targetCharacter.Name} is dead and cannot be healed.");
            }
            else
            {
                int healAmount = 10; // Example heal amount
                targetCharacter.Health += healAmount;
                Console.WriteLine($"{targetCharacter.Name} has been healed for {healAmount} health!");
            }
        }
        public void Fireball(Character targetCharacter)
        {
            if (targetCharacter.Health <= 0)
            {
                Console.WriteLine($"{targetCharacter.Name} is dead and cannot be affected by fireball.");
            }
            else
            {
                int damage = 20; // Example fireball damage
                targetCharacter.Health -= damage;
                Console.WriteLine($"{targetCharacter.Name} has been hit by a fireball for {damage} damage!");
            }
        }
        public void Petrify(Character targetCharacter)
        {
            if (targetCharacter.IsStunned)
            {
                Console.WriteLine($"{targetCharacter.Name} is already petrified.");
            }
            else
            {
                targetCharacter.IsStunned = true;
                Console.WriteLine($"{targetCharacter.Name} has been petrified!");
            }
        }
    }
}
