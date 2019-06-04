using System;

namespace Hangman
{
    public interface ISecretWord
    {
        string Word { get; }

        bool Contains(char c);
        string GetPartiallySolved(Func<char, bool> CharIsKnown);
        bool IsSolvedBy(Func<char, bool> CharIsKnown);
        bool IsWord(string s);
    }
}