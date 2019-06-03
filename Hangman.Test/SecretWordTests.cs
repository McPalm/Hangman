using NUnit.Framework;
using Hangman;

namespace Tests
{


    public class SecretWordTests
    {

        [Test]
        [TestCase("Hi", "", "__")]
        [TestCase("Hi", "h", "H_")]
        [TestCase("Hi", "i", "_i")]
        [TestCase("Hi", "ih", "Hi")]
        [TestCase("Tom Bombadil", "body", "_o_ Bo_b_d_l")]
        public void GetPartiallySolved_HappyPath(string word, string known, string expected)
        {
            var secretWord = new SecretWord(word);
            var result = secretWord.GetPartiallySolved(KnownCharFunction(known));
            Assert.That(result, Is.EqualTo(expected));
        }


        System.Func<char, bool> KnownCharFunction(string known)
        {
            return (c) => {
                return known.ToLower().Contains(c)
                || known.ToUpper().Contains(c);
            };
        }
    }
}