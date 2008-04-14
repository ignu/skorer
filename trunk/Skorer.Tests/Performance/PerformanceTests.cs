using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Iesi.Collections.Generic;

namespace Skorer.Tests
{
    [TestFixture]
    public class CastingToListTest
    {
        ISet<string> randomStrings = new HashedSet<string>();
        //private int numberInList = 5000;
        private int numberInList = 5;

        [SetUp]
        public void SetUp()
        {
            for (int i = 0; i < numberInList; i++)
            {
                randomStrings.Add(Guid.NewGuid().ToString());
            }
        }

        [Test]
        public void Casting_To_List()
        {
            string rv = String.Empty;

            for (int i = 0; i < 1000000; i++)
            {
                rv = new List<string>(randomStrings)[new Random(DateTime.Now.Millisecond).Next(5000)];
            }

            Console.WriteLine(rv);
        }

        [Test]
        public void Casting_To_List_Once()
        {
            string rv = String.Empty;

            List<string> listStrings = new List<string>(randomStrings);

            for (int i = 0; i < 1000000; i++)
            {
                rv =listStrings[new Random(DateTime.Now.Millisecond).Next(5000)];
            }
            Console.WriteLine(rv);
        }

    }
}
