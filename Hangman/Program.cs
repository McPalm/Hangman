using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStart();
            CompleteLoop();
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

        static void CompleteLoop()
        {
            var words = new WordPicker();
            do
            {
                GameLoop(words.Next());
                Console.WriteLine();
                Console.WriteLine("Play again? (y/n)");

            } while (words.HasNext && ConfirmYN());
            Console.Clear();
            if (words.HasNext == false)
                Console.WriteLine("Out of words...");
            Console.WriteLine("Thank you for playing!");
        }

        static bool ConfirmYN()
        {
            for(; ; )
            {
                var c = Console.ReadKey(true);
                if (c.Key == ConsoleKey.Y)
                    return true;
                if (c.Key == ConsoleKey.N)
                    return false;
            }
        }

        static void GameLoop(string word)
        {
            var secret = new SecretWord(word);
            var game = new WordGame(secret, 10);
            RenderSet(game, 10);
            while(game.GameOver == false)
            {
                Console.WriteLine("Guess a letter or the whole word");
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
                    Console.ReadKey(true);
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
                    Console.WriteLine($"You lose!\n" +
                        $"The word was: {game.WholeWord}");
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
