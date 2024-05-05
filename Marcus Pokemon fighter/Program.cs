namespace Marcus_Pokemon_fighter
{
    internal partial class Program
    {
        //https://sharplab.io/#v2:C4LgTgrgdgNAJiA1AHwAICYAMBYAUBgRjz1QGYACDcgYQENhyRyBBKASwFtaAbPAbzzkhlCqgKZyAOVocApgG5BwsuTZQGzAOYKlQ3eX0q6wABQBlYGDWbyUGbJir15WtoCU+gbmE/pc8gC8tvbyBt4+QlqygS7aiuFCAL7ECSLkAPYAbrJgVnDRYhIA4rLAZgAOsgDGbLIAziYeqV4RygDs5ABExp3xPsm4hhRZOXkFACzkAApW6o2e+j4ARrR1sgB0M2qmbn2tlAQAnCYAJJ12ciB8frKJnbuLykenna6yV1F3D6kDAySi6HIABk2OkoIwaPR+CkfCpCuQALK0KCyajpbjpMB7PSpIbA0FQEzwi4OJwMN6OeFcFFojFgJr7CErNbkEwkxxvBnCFqM4RImnozExamowVY/QDHx4ka5Nj5A7FUoVaq1BpcoQ81qoDqdEFg3oS/TS7Ky+WoSZbObq8iaiLMjaWnbYiJiY5nPj80V0r7O34pf4uJZ1Sy0KoMKisTg8aEJFSZNhgYAQHiUC2zHa6W1PY4lMqVGr1Rq7YS6SU45QUWhBkNhhXkXPKgtq+J/fAAlhgLhwNjcDEQyNcXi4Lx4jFQGxmNgALx0qTh4ikITx2xYcTxzE7tG7vfSRIX7LJsVJY5sdWnsnVC1SPknM5iZ5nzt89hiJKfwiiMTevuNozlBQXBt81VeZmkeIRtS6WhN23DFeilH5f1NCZpnTUCfCzZZVgdNDi3LRlXRePhb1ue532zIibh9cCIOed1PjImiwn6Gi8FbKhqBjWF0HQTxGVY69hD1cEACt0miIIUQAd3xMETE6AApcTOkcdBHE6ABPWQdykxjBPw1oxJw7ZGnI5j9mMcgACF0iWV9ZBk4x5IAUTgfIoBU8gCAADjw8zWgExkbKWTZcLMwL9g3Lsez7BTQwAa3smSoq3GLd06ESEs88RMBgHLMAKwqiuK75+P08g4qqeLQpM0rhF+IA
        //inheritance reintro ^
        static void Main()
        {
            BasePokemon UserPokemon;
            BasePokemon EnemyPokemon;
            Random randomGen = new Random();
            int testSubjects = 5;
            bool isPlaying = true;
            bool PlayerTurn = false;

            BasePokemon[] pokemons = {
            new Hakop(),
            new Nikita(),
            new Zanlin(),
            new Edden(),
            new Wailinn()
            };


            BasePokemon currPokemon;
            BasePokemon otherPokemon;

            #region SetUp
            Console.WriteLine("Welcome to Pokemon fighter");

            Console.WriteLine("Please choose a character");

            for (int i = 0; i < testSubjects; i++)
            {
                Console.WriteLine($"{i}");
                pokemons[i].DisplayInfo();
            }

            string pickPokemonResponse = Console.ReadLine();
            int pickPokemon;

            while (!int.TryParse(pickPokemonResponse, out pickPokemon) || pickPokemon > 6 || pickPokemon < 0)
            {
                Console.WriteLine("Thats not a valid response try again.");
                Console.WriteLine("Please choose a character");

                for (int i = 0; i < testSubjects; i++)
                {
                    Console.WriteLine($"{i}");
                    pokemons[i].DisplayInfo();
                }
                pickPokemonResponse = Console.ReadLine();
            }
            UserPokemon = pokemons[pickPokemon];

            Console.WriteLine($"You have picked {UserPokemon.Name}");
            Console.WriteLine("Marcus Bot is choosing a character...");

            int botPickedPokemon = randomGen.Next(pokemons.Length);

            EnemyPokemon = pokemons[botPickedPokemon];

            Console.WriteLine($"Marcus bot has picked {EnemyPokemon.Name}");

            Console.WriteLine("We are now going to flip a coin to see who will be having the first turn. (1)Heads or (2)Tails?");

            string coinFlipResponse = Console.ReadLine();
            int coinFlip;

            while (!int.TryParse(coinFlipResponse, out coinFlip) && 0 < coinFlip && coinFlip < 3)
            {
                Console.WriteLine("This is not a valid response please try again");

                Console.WriteLine("We are now going to flip a coin to see who will be having the first turn. (1)Heads or (2)Tails?");

                coinFlipResponse = Console.ReadLine();
            }
            int randomRandomCoinFlip = randomGen.Next(1, 2);

            if (randomRandomCoinFlip == coinFlip)
            {
                Console.WriteLine("You have picked right! It is now your turn.");
                PlayerTurn = true;
            }
            else
            {
                Console.WriteLine("You have picked wrong! It is now Marcus Bot's turn.");
                Console.WriteLine("+1 Chat from Marcus Bot");
                Console.WriteLine("You are going down stupid noob.");
                PlayerTurn = false;
                currPokemon = EnemyPokemon;
                otherPokemon = UserPokemon;
            }
            #endregion

        

            if (PlayerTurn == true)
            {
                currPokemon = UserPokemon;
                otherPokemon = EnemyPokemon;
            }
            else 
            {
                currPokemon = EnemyPokemon;
                otherPokemon = UserPokemon;
            }

            while (isPlaying)
            {
                int enemyNumber = 0;
                int userDecisionNumber = 0;
                if (PlayerTurn == true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("(1)Attack, (2)Special Attack, (3)Heal, (4)Block Attack");
                    string userDecision = Console.ReadLine();

                    while (!int.TryParse(userDecision, out userDecisionNumber) && userDecisionNumber !> 4 && userDecisionNumber != 0)
                    {
                        Console.WriteLine("Give a valid response");

                        Console.WriteLine("(1)Attack, (2)Special Attack, (3)Heal, (4)Block Attack");

                        userDecision = Console.ReadLine();
                    }
                }
                else if(PlayerTurn == false)
                {
                    enemyNumber = randomGen.Next(1, 5);
                }




                int attackState = 0;
                if(PlayerTurn == true)
                {
                    attackState = userDecisionNumber;
                }
                else if(PlayerTurn == false)
                {
                    attackState = enemyNumber;
                }
//                PlayerTurn == true ? userDecisionNumber : enemyNumber
                switch (attackState)
                { 
                    case 1:
                        //do atack logic\
                        currPokemon.Attack(otherPokemon);
                        //Console.WriteLine($"You hit {EnemyPokemon.Name} for {UserPokemon.AttackDamage} damage. {EnemyPokemon.Name} is now at {EnemyPokemon.Health} health.");
                        break;

                    case 2:
                        //do stuff
                        currPokemon.SpecialAttack(otherPokemon);
                        break;

                    case 3:
                        currPokemon.Healed();
                        break;

                    case 4:

                        currPokemon.isBlocking = true;
                        Console.WriteLine($"{currPokemon.Name} is blocking");
                        break;
                }

                //Makes playerturn not playerturn
                PlayerTurn = !PlayerTurn;

                BasePokemon temp = currPokemon;
                currPokemon = otherPokemon;
                otherPokemon = temp;


                

                //switch(enemyNumber)
                //{
                //    case 1:
                //        //do atack logic\
                //        EnemyPokemon.Attack(EnemyPokemon);
                //        PlayerTurn = false;
                //        break;

                //    case 2:
                //        //do stuff
                //        EnemyPokemon.SpecialAttack(EnemyPokemon);
                //        PlayerTurn = false;
                //        break;

                //    case 3:
                //        EnemyPokemon.Healed();
                //        PlayerTurn = false;
                //        break;

                //    case 4:
                //        EnemyPokemon.Block(EnemyPokemon);
                //        PlayerTurn = false;
                //        break;
                //}
            }
            //do game logic based on playerTurn
            //it is already set
            //you set it with the coinflip
            //if(PlayerTurn) Pokemon currentPlayer = player
            //else currentPlayer = opponent

            //do logic on current player

            //flip turn
        }

    }
}
