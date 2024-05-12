namespace Marcus_Pokemon_fighter
{
    internal partial class Program
    {
        public class Hakop : BasePokemon
        {
           
            public Hakop()//string attackName, string specialName, int health, int attackDamage, int heal, int amountBlocked, int specialDamage)
                : base("Hakop", "beard", "dunk", 100, 8, 10, 15, 20, 5)
            {

            }

            public override void SpecialAttack(BasePokemon target)
            {
                if (roundCounter >= CoolDownAmount)
                {
                    isBlocking = false;

                    if (target.isBlocking == false)
                    {

                        Console.WriteLine($"{Name} hit {target.Name} with {SpecialDamage} for {SpecialDamage} damage.");
                        target.Health -= SpecialDamage;

                        Console.WriteLine($"{Name} health: {Health}");
                        Console.WriteLine($"{target.Name} Health: {target.Health}");
                    }
                    else if (target.isBlocking == true)
                    {
                        target.Block(this);

                        Console.WriteLine($"{Name} health: {Health}");
                        Console.WriteLine($"{target.Name} Health: {target.Health}");
                    }

                    roundCounter = 0;
                }
                else if (roundCounter < 5)
                {

                    Console.WriteLine("You can't use this move yet. You've wasted a move. Too bad.");

                }

                
               
            }
        }

    }
}