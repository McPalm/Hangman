using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class SecretWord
    {
        public String Word { get; }

        public SecretWord(string word)
        {
            Word = word;
        }

        /// <summary>
        /// Returns the string, only showing revealed characters, hidden characters are replaced with a _
        /// </summary>
        /// <param name="revealed"></param>
        /// <returns></returns>
        public string GetPartiallySolved(Func<char, bool> CharIsKnown)
        {
            var chars = new char[Word.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                if (Word[i] == ' ' || CharIsKnown(Word[i]))
                    chars[i] = Word[i];
                else
                    chars[i] = '_';
            }
            return new string(chars);
        }

        public bool IsSolvedBy(Func<char, bool> CharIsKnown)
        {
            throw new NotImplementedException();
        }
    }
}
