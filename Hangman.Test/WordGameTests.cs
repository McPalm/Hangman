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
        WordGame game { get; set; }
        Mock<ISecretWord> moqSecretWord { get; set; }

        [SetUp]
        public void SetUp()
        {
            moqSecretWord = new Mock<ISecretWord>();
            game = new WordGame(moqSecretWord.Object, 10);
        }

        [Test]
        [TestCase('/')]
        [TestCase('_')]
        [TestCase('.')]
        [TestCase('1')]
        public void MakeAGuess_InvalidCharacter_ReturnsFalse(char c)
        {
            var result = game.MakeAGuess(c);
            Assert.IsFalse(result);
        }
    }
}
