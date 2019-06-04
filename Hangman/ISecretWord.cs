using System;

namespace Hangman
{
    public interface ISecretWord
    {
        string Word { get; }

        string GetPartiallySolved(Func<char, bool> CharIsKnown);
        bool IsSolvedBy(Func<char, bool> CharIsKnown);
    }
}