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
        [TestCase('ä')]
        public void MakeAGuess_InvalidCharacter_ReturnsFalse(char c)
        {
            var result = Game.MakeAGuess(c);
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase('a')]
        [TestCase('A')]
        [TestCase('a')]
        [TestCase('Z')]
        [TestCase('r')]
        [TestCase('d')]
        [TestCase('s')]
        [TestCase('y')]
        public void MakeAGuess_ValidCharacter_ReturnsTrue(char c)
        {
            var result = Game.MakeAGuess(c);
            Assert.IsTrue(result);
        }
    }
}
