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
                else
                {
                    Console.WriteLine("Guesses has to be single characters");
                    Console.ReadKey();
                }

                RenderSet(game, 10);
            }
        }

        static void RenderSet(WordGame game, int maxGuesses)
        {
            Console.Clear();
            Console.WriteLine($"{game.VisibleWord}");
            var guessed = string.Join(' ', game.GuessedCharacters);
            Console.WriteLine(guessed);
            

            if (game.GameOver)
            {
                if (game.Solved)
                    Console.WriteLine($"Congratulations, you win!");
                else
                    Console.WriteLine($"You lose!");
            }
            else
                Console.WriteLine($"{maxGuesses - game.TotalGuesses} guesses left..");
        }
    }
}
