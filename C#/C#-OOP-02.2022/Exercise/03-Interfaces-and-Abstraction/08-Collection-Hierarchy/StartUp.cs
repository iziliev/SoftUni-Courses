using _08_Collection_Hierarchy.Models;
using System;

namespace _08_Collection_Hierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            var items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var removeOperation = int.Parse(Console.ReadLine());

            var matrixAdd = new int[3][];
            var matrixRemove = new string[2][];

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var mylist = new MyList();

            FillAddMatrix(items, matrixAdd, addCollection, addRemoveCollection, mylist);

            FillRemoveMatrix(removeOperation, matrixRemove, addRemoveCollection, mylist);

            PrintMatrix(matrixAdd, matrixRemove);
        }

        private static void PrintMatrix(int[][] matrixAdd, string[][] matrixRemove)
        {
            foreach (var row in matrixAdd)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            foreach (var row in matrixRemove)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillRemoveMatrix(int removeOperation, string[][] matrixRemove, AddRemoveCollection addRemoveCollection, MyList mylist)
        {
            for (int i = 0; i < matrixRemove.Length; i++)
            {
                var array = new string[removeOperation];
                if (i == 0)
                {
                    for (int j = 0; j < removeOperation; j++)
                    {
                        array[j] = addRemoveCollection.RemoveItem();
                    }
                }
                else
                {
                    for (int j = 0; j < removeOperation; j++)
                    {
                        array[j] = mylist.RemoveItem();
                    }
                }

                matrixRemove[i] = array;
            }
        }

        private static void FillAddMatrix(string[] items, int[][] matrixAdd, AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList mylist)
        {
            for (int i = 0; i < matrixAdd.Length; i++)
            {
                var array = new int[items.Length];
                if (i == 0)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        array[j] = addCollection.AddItems(items[j]);
                    }
                }
                else if (i == 1)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        array[j] = addRemoveCollection.AddItems(items[j]);
                    }
                }
                else if (i == 2)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        array[j] = mylist.AddItems(items[j]);
                    }
                }
                matrixAdd[i] = array;
            }
        }
    }
}
