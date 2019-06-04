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

        [Test]
        public void MakeAGuess_SameCharacter_ReturnsFalse()
        {
            Game.MakeAGuess('a');
            var result = Game.MakeAGuess('a');
            Assert.IsFalse(result);
        }

        [Test]
        public void MakeAGuess_CapitalLetterVariant_ReturnsFalse()
        {
            Game.MakeAGuess('a');
            var result = Game.MakeAGuess('A');
            Assert.IsFalse(result);
        }

        [Test]
        public void TotalGuesses_ThreeUniqueGuesses_Returns3()
        {
            Game.MakeAGuess('a');
            Game.MakeAGuess('b');
            Game.MakeAGuess('c');

            var result = Game.TotalGuesses;
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void TotalGuesses_GuessSameThreeTimes_Returns2()
        {
            Game.MakeAGuess('a');
            Game.MakeAGuess('A');
            Game.MakeAGuess('a');

            var result = Game.TotalGuesses;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(0, 10, false)]
        [TestCase(9, 10, false)]
        [TestCase(9, 9, true)]
        [TestCase(10, 10, true)]
        [TestCase(12, 10, true)]
        public void GameOver_AfterXGuesses(int guesses, int max, bool expected)
        {
            Game = new WordGame(MoqSecretWord.Object, max);
            for (int i = 0; i < guesses; i++)
            {
                Game.MakeAGuess((char)('a' + i));
            }
            var result = Game.GameOver;
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
