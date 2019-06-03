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
            throw new NotImplementedException();
        }

        public bool IsSolvedBy(Func<char, bool> CharIsKnown)
        {
            throw new NotImplementedException();
        }
    }
}
