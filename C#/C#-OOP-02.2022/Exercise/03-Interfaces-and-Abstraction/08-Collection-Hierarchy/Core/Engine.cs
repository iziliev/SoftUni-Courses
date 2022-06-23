using _08_Collection_Hierarchy.Contracts;
using _08_Collection_Hierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Core
{
    public class Engine
    {
        private const string addCollection = "addCollection";
        private const string addRemoveCollection = "addRemoveCollection";
        private const string myList = "myList";

        private Dictionary<string, IAddCollection> collections = new Dictionary<string, IAddCollection>()
            {
                {addCollection, new AddCollection() },
                {addRemoveCollection, new AddRemoveCollection() },
                {myList, new MyList() }
            };

        public void Run()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var removeCount = int.Parse(Console.ReadLine());

            var matrixInt = new Dictionary<string, int[]>()
            {
                {addCollection, new int[input.Length] },
                {addRemoveCollection, new int[input.Length] },
                {myList, new int[input.Length] }
            };

            var count = Math.Min(input.Length, removeCount);

            var matrixString = new Dictionary<string, string[]>()
            {
                {addRemoveCollection, new string[count] },
                {myList, new string[count] }
            };

            for (int i = 0; i < input.Length; i++)
            {
                matrixInt[addCollection][i] = collections[addCollection].Add(input[i]);
                matrixInt[addRemoveCollection][i] = collections[addRemoveCollection].Add(input[i]);
                matrixInt[myList][i] = collections[myList].Add(input[i]);
            }

            for (int i = 0; i < count; i++)
            {
                matrixString[addRemoveCollection][i] = ((AddRemoveCollection)collections[addRemoveCollection]).Remove();
                matrixString[myList][i] = ((MyList)collections[myList]).Remove();
            }

            foreach (var collection in matrixInt)
            {
                Console.WriteLine(string.Join(" ", collection.Value));
            }
            
            foreach (var collection in matrixString)
            {
                Console.WriteLine(string.Join(" ", collection.Value));
            }
        }
    }
}
