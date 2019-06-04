using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStart();
            GameLoop();
        }

        static void GameStart()
        {
            Console.WriteLine("Welcome to a game of Hangman!\n" +
                "I have generated a secret word, you have to guess what the world is, character by characters\n" +
                "If you guess wrong 10 times, you lose.\n" +
                "If you guess right, you win!\n" +
                "Press any key to start");
            Console.ReadKey();
        }

        static void GameLoop()
        {
            var secret = new SecretWord("Hello World");
            var game = new WordGame(secret, 10);
            RenderSet(game, 10);
            while(game.GameOver == false)
            {
                Console.WriteLine("Guess a word: ");
                var input = Console.ReadLine();
                if(input.Length == 1f && game.MakeAGuess(input[0]))
                { 

                }
                else if(input.Length > 1)
                {
                    game.MakeAGuess(input);
                }
                else if(input.Length > 0)
                {
                    if (WordGame.IsValidCharacter(input[0]))
                        Console.WriteLine("Cannot guess the same letter twice.");
                    else
                        Console.WriteLine("Only letters a-z is accepted");
                    Console.ReadKey();
                }

                RenderSet(game, 10);
            }
        }

        static void RenderSet(WordGame game, int maxGuesses)
        {
            Console.Clear();
            Console.WriteLine($"{game.VisibleWord}");
            var guessed = string.Join(' ', game.IncorrecteGuesses);
            Console.WriteLine(guessed);
            

            if (game.GameOver)
            {
                if (game.Solved)
                    Console.WriteLine($"Congratulations, you win!");
                else
                    Console.WriteLine($"You lose!");
            }
            else
            {
                var left = maxGuesses - game.TotalGuesses;
                if (left == 1)
                    Console.WriteLine("Last guess! Make it count");
                else
                    Console.WriteLine($"{left} guesses left..");
            }
        }
    }
}
