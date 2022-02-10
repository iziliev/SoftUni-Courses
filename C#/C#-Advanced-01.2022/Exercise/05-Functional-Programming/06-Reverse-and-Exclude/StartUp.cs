using System;
using System.Linq;

namespace _06_Reverse_and_Exclude
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var reverceArr = new int[numbers.Length];

            Func<int[], int[]> reverceFunc = numbers =>
             {
                 var index = 0;
                 for (int i = numbers.Length - 1; i >= 0; i--)
                 {
                     reverceArr[index] = numbers[i];
                     index++;
                 }
                 return reverceArr;
             };

            reverceArr = reverceFunc(numbers);

            var devide = int.Parse(Console.ReadLine());

            Predicate<int> predicate = x => x % devide == 0;

            Console.WriteLine(String.Join(" ", reverceArr.Where(x => !predicate(x))));
        }
    }
}
