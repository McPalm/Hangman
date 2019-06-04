using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class WordPicker
    {
        int count = 0;
        public WordPicker(int seed = -1)
        {
            if (seed == -1)
                seed = DateTime.Now.Millisecond;
            var random = new System.Random(seed);
            worldsScrambled = new List<string>(Words);
            worldsScrambled.Sort((a, b) => random.Next(2) == 1 ? -1 : 1);
        }

        List<string> worldsScrambled { get; set; }

        public bool HasNext => count < worldsScrambled.Count;
        public string Next()
        {
            return worldsScrambled[count++];
        }

        readonly string[] Words =
        {
            "Hello World",
            "Abacus",
            "Pony",
            "Pink Elephant",
            "Bombshell",
            "Clydesdale",
            "Domino Brick",
            "Ehecatl",
            "Fish",
            "Gym",
            "Height",
            "Jolly",
            "Macaronies",
            "Zebra",
            "Foppish",
            "Faze",
            "Skyjacking",
            "Buzzsaw",
            "Fluffy",
            "Buffalo buffalo Buffalo buffalo buffalo buffalo Buffalo buffalo",
        };
    }
}
