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
        [TestCase("Tom Bombadil", "body", "_o_ Bo_b_d__")]
        [TestCase("Tom tom", "mot", "Tom tom")]
        public void GetPartiallySolved(string word, string known, string expected)
        {
            var secretWord = new SecretWord(word);
            var result = secretWord.GetPartiallySolved(KnownCharFunction(known));
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        [TestCase("Hi", "", false)]
        [TestCase("Hi", "ih", true)]
        [TestCase("Hello World", "hello world", true)]
        [TestCase("Hello World", "helloworld", true)]
        [TestCase("Hello World", "hell word", true)]
        [TestCase("This is not a word", "hello world", false)]
        public void IsSolvedBy(string word, string known, bool expected)
        {
            var secretWord = new SecretWord(word);
            var result = secretWord.IsSolvedBy(KnownCharFunction(known));
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("hello", 'h', true)]
        [TestCase("hello", 'L', true)]
        [TestCase("ello", 'h', false)]
        [TestCase("hEllo", 'e', true)]
        [TestCase("hEllo", 'g', false)]
        public void Contains(string word, char letter, bool expected)
        {
            var secret = new SecretWord(word);
            var result = secret.Contains(letter);
            Assert.That(result, Is.EqualTo(result));
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