using System;

namespace P01_Blank_Receipt
{
    class Blank_Receipt
    {
        static void Main()
        {
            PrintTop();
            PrintMiddle();
            PrintBottom();
        }
        static void PrintTop()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        static void PrintMiddle()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void PrintBottom()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("© SoftUni");
        }
    }
}
