namespace P06_Catch_the_Thief
{
    using System;
    class Catch_the_Thief
    {
        static void Main()
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            long maxNumber = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();

                try
                {
                    if (type == "sbyte")
                    {
                        sbyte nums = sbyte.Parse(number);
                        if (sbyte.MinValue <= nums && sbyte.MaxValue >= nums)
                        {
                            if (maxNumber < nums)
                            {
                                maxNumber = nums;
                            }
                        }
                    }
                    else if (type == "int")
                    {
                        int nums = int.Parse(number);
                        if (int.MinValue <= nums && int.MaxValue >= nums)
                        {
                            if (maxNumber < nums)
                            {
                                maxNumber = nums;
                            }
                        }
                    }
                    else if (type == "long")
                    {
                        long nums = long.Parse(number);
                        if (long.MinValue <= nums && long.MaxValue >= nums)
                        {
                            if (maxNumber < nums)
                            {
                                maxNumber = nums;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            Console.WriteLine(maxNumber);
        }
    }
}
