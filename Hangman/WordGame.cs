using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class WordGame
    {
        public int TotalGuesses { get; }
        public IEnumerator<char> GuessedCharacters { get; }
        /// <summary>
        /// True if the game is over, whenever or not we won
        /// </summary>
        public bool GameOver { get; }
        public bool Solved { get; }
        /// <summary>
        /// What we can see so far, just underscores and spaces if nothing is known, and the whole word if completely solved
        /// </summary>
        public string VisibleWord { get; }


        public WordGame(SecretWord secretWord)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Guess a character.
        /// Rejects bad inputs with a false return
        /// </summary>
        /// <param name="c"></param>
        /// <returns>false if the guess was invalid, such as the character has alredy been guessed or is not a common letter.</returns>
        public bool MakeAGuess(char c)
        {
            throw new NotImplementedException();
        }

    }
}
