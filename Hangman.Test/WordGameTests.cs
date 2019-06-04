using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Test
{
    [TestFixture]
    class WordGameTests
    {
        WordGame Game { get; set; }
        Mock<ISecretWord> MoqSecretWord { get; set; }

        [SetUp]
        public void SetUp()
        {
            MoqSecretWord = new Mock<ISecretWord>();
            Game = new WordGame(MoqSecretWord.Object, 10);
        }

        [Test]
        [TestCase('/')]
        [TestCase('_')]
        [TestCase('.')]
        [TestCase('1')]
        public void MakeAGuess_InvalidCharacter_ReturnsFalse(char c)
        {
            var result = Game.MakeAGuess(c);
            Assert.IsFalse(result);
        }
    }
}
