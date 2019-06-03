using NUnit.Framework;
using Hangman;

namespace Tests
{


    public class SecretWordTests
    {
        SecretWord Word { get; set; }


        [SetUp]
        public void Setup()
        {
            Word = new SecretWord();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}