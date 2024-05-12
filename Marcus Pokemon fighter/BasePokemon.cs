using System.Net.Cache;

namespace Marcus_Pokemon_fighter
{

    //pokemon figheter
    //base pokemon class (ABSTRACT)
    //each pokemon should have health, name, attack, heal, block, and special
    //everything is the same in all of them besides special (besides damage amount of attack or amount of heal, and block)
    //Special does something unique in all pokemon (skip turn, critical hit, whatever)
    //One of the pokemon, their special negates the other pokemons for the rest of the game (figure out how to do it) 
    //  it calls the base pokemon special (whatever you want, i.e +1)
    //there is a selection stage of 2 pokemons each (start with just 1v1 and then scale it up if you want)
    //first one to have all their pokemon die loses

    //make menu to choose pokemon
    //homputer choose it's pokemon
    //let player choose move
    //comp chooses move
    //repeat until death

    public abstract class BasePokemon
    {
        public string Name;
        public string AttackName;
        public string SpecialName;

        public int Health;
        public int AttackDamage;
        public int Heal;
        public int AmountBlocked;
        public int SpecialDamage;

        private bool isBlocking;
        make sure to change everything to the big IsBlocking
        public bool IsBlocking
        {
            get
            {
                return isBlocking;
            }
            set
            {
                isBlocking = value;
                if(!isBlocking)
                {
                    roundCounter++;
                }
            }
        };
        public int roundCounter = 0;

        public int CoolDownAmount = 0;

        public BasePokemon(string name, string attackName, string specialName, int health, int attackDamage, int heal, int amountBlocked, int specialDamage, int coolDownAmount)
        {
            Name = name;
            AttackName = attackName;
            SpecialName = specialName;
            Health = health;
            AttackDamage = attackDamage;
            Heal = heal;
            AmountBlocked = amountBlocked;
            SpecialDamage = specialDamage;
            CoolDownAmount = coolDownAmount;
        }

        public void Attack(BasePokemon target)
        {
            isBlocking = false;

            if (target.IsBlocking == false)
            {

                Console.WriteLine($"{Name} hit {target.Name} with {AttackName} for {AttackDamage} damage.");
                target.Health -= AttackDamage;

                Console.WriteLine($"{Name} health: {Health}");
                Console.WriteLine($"{target.Name} Health: {target.Health}");
            }
            else if (target.isBlocking == true)
            {
                target.Block(this);

                Console.WriteLine($"{Name} health: {Health}");
                Console.WriteLine($"{target.Name} Health: {target.Health}");
            }
            roundCounter++;
        }

        public abstract void SpecialAttack(BasePokemon target); //FIX THIS foh4ofh4h43fh34ufh34fh34hfu43hfi43hfi34hfi43hf3ih4fihfi34hfi4hfui34hfi3hfi34hfi34hfi344hf34fifh3i4fh round counter passed in from program
        


        public void Block(BasePokemon target)
        {
            isBlocking = false;
            Console.WriteLine($"{Name} blocked an attack");
            if (AmountBlocked <= target.AttackDamage)
            {
                Health -= (target.AttackDamage - AmountBlocked);
            }
            else if (AmountBlocked > target.AttackDamage)
            {
                int difference;
                difference = AmountBlocked - target.AttackDamage;

                Health -= (target.AttackDamage - AmountBlocked) + difference;
            }

            Console.WriteLine($"{Name} health: {Health}");
            Console.WriteLine($"{target.Name}: {target.Health}");
            roundCounter++;
        }




        public void Healed()
        {
            isBlocking = false;
            Console.WriteLine($"{Name} has healed himself for {Heal} health");
            Health += Heal;

            Console.WriteLine($"{Name} health: {Health}");
            roundCounter++;

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name:{Name}, Attack:{AttackName}, Special Attack:{SpecialName}, Health:{Health}, Attack Damage:{AttackDamage}, Heal Amount:{Heal}, Amount of Damage that can be blocked:{AmountBlocked}, Special Damage:{SpecialDamage}");
        }
    }
}
