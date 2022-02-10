namespace P01_X
{
    using System;
    class X
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}",
                                 new String(' ', i - 1),
                                 new String(' ', n - 2 - i + 1 - i + 1));
            }
            Console.WriteLine("{0}x{0}", new String(' ', (n - 1) / 2));

            for (int i = (n - 1) / 2; i > 0; i--)
            {
                Console.WriteLine("{0}x{1}x{0}",
                                 new String(' ', i - 1),
                                 new String(' ', n - 2 - i + 1 - i + 1));
            }
        }
    }
}
