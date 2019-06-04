using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class WordGame
    {
        public int TotalGuesses { get; private set; }
        public IEnumerable<char> GuessedCharacters => new List<char>(guessedCharacters);
        /// <summary>
        /// True if the game is over, whenever or not we won
        /// </summary>
        public IEnumerable<char> CorrectGuesses => GuessedCharacters.Where(c => SecretWord.Contains(c));
        public IEnumerable<char> IncorrecteGuesses => GuessedCharacters.Where(c => !SecretWord.Contains(c));
        public bool GameOver => TotalGuesses >= GuessLimit || Solved;
        public bool Solved => SecretWord.IsSolvedBy(guessedCharacters.Contains);
        /// <summary>
        /// What we can see so far, just underscores and spaces if nothing is known, and the whole word if completely solved
        /// </summary>
        public string VisibleWord => SecretWord.GetPartiallySolved(guessedCharacters.Contains);
        ISecretWord SecretWord { get; }
        public string WholeWord => SecretWord.Word;
        int GuessLimit { get; }
        HashSet<char> guessedCharacters = new HashSet<char>();

        public WordGame(ISecretWord secretWord, int guessLimit)
        {
            SecretWord = secretWord;
            GuessLimit = guessLimit;
        }


        /// <summary>
        /// Guess a character.
        /// Rejects bad inputs with a false return
        /// </summary>
        /// <param name="c"></param>
        /// <returns>false if the guess was invalid, such as the character has alredy been guessed or is not a common letter.</returns>
        public bool MakeAGuess(char c)
        {
            c = Char.ToLower(c);
            if(IsValidCharacter(c) == false)
                return false;
            if(guessedCharacters.Add(c))
            {
                TotalGuesses++;
                return true;
            }
            return false;
        }

        public bool MakeAGuess(string word)
        {
            foreach (char c in word)
                if (IsValidCharacter(c) == false && c != ' ')
                    return false;

            if(SecretWord.IsWord(word))
            {
                foreach (var c in word)
                {
                    guessedCharacters.Add(c);
                }
            }
            TotalGuesses++;
            return true;
        }

        static public bool IsValidCharacter(char c)
        {
            return (c >= 'a' && c <= 'z')
                || (c >= 'A' && c <= 'Z');
        }
    }
}
