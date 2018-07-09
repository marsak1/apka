using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoloteaUIAutomation.Utilities.Helpers
{
    public class RandomGenerator
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static IWebElement GetRandomElementFromList(IList<IWebElement> listLocator)
        {
            int count = listLocator.Count;
            int chosenIndex = random.Next(0, count - 1);
            return listLocator[chosenIndex];
        }

        public static int GetRandomNumber(int number)
        {
            return random.Next(number);
        }

        public static String GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                ch = Char.ToLower(ch);
                if (i % 3 == 0) ch = Char.ToUpper(ch);
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static String GetRandomSentence()
        {
            return GetRandomSentences(1);
        }

        public static String GetRandomSentences(int howMany)
        {
            StringBuilder builder = new StringBuilder();

            var sentence = new NLipsum.Core.LipsumGenerator().GenerateSentences(howMany);
            foreach (string s in sentence) builder.Append(s);

            return builder.ToString();
        }

        public static string RandomEmailGenerator(int size){
            string email;
            RandomGenerator random = new RandomGenerator();

            string name = GetRandomString(size);
            string firstDomain = GetRandomString(size);
            string secondDomain = GetRandomString(3);
            
            email = name + '@' + firstDomain + '.' + secondDomain;
            return email;
        }
    }
}
