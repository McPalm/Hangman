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
        Mock<ISecretWord> MockSecretWord { get; set; }

        [SetUp]
        public void SetUp()
        {
            MockSecretWord = new Mock<ISecretWord>();
            Game = new WordGame(MockSecretWord.Object, 10);
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
            Game = new WordGame(MockSecretWord.Object, max);
            for (int i = 0; i < guesses; i++)
            {
                Game.MakeAGuess((char)('a' + i));
            }
            var result = Game.GameOver;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Solved_AfterWinning()
        {
            MockSecretWord.Setup(sw => sw.IsSolvedBy(It.IsAny<Func<char, bool>>())).Returns(true);
            var result = Game.Solved;
            Assert.IsTrue(result);
        }
        [Test]
        public void GameOver_AfterWinning()
        {
            MockSecretWord.Setup(sw => sw.IsSolvedBy(It.IsAny<Func<char, bool>>())).Returns(true);
            var result = Game.GameOver;
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("")]
        [TestCase("a")]
        [TestCase("asd")]
        public void GuessedCharacter_AfterGuessing_ContainsExpectedCharacters(string guesses)
        {
            foreach (char c in guesses.ToCharArray())
                Game.MakeAGuess(c);
            var result = Game.GuessedCharacters;
            Assert.That(result, Is.EquivalentTo(guesses.ToCharArray()));
        }

        [Test]
        public void VisibleWord_Request_ValueProvidedBySecretWord()
        {
            string word = "Hell_ w_rld";
            MockSecretWord.Setup(sw => sw.GetPartiallySolved(It.IsAny<Func<char, bool>>())).Returns(word);

            var result = Game.VisibleWord;
            Assert.That(word, Is.EqualTo(result));
            
        }
    }
}
