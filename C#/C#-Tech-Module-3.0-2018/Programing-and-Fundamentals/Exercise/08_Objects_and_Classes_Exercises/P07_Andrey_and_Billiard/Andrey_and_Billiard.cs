using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Andrey_and_Billiard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ShopingList { get; set; }
        public decimal Bill { get; set; }
    }

    class Andrey_and_Billiard
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> priceList = new Dictionary<string, decimal>();

            List<Customer> customersProducts = new List<Customer>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                if (!priceList.ContainsKey(product))
                {
                    priceList.Add(product, price);
                }
                else
                {
                    priceList[product] = price;
                }
            }

            string boughtProd = Console.ReadLine();

            while (boughtProd != "end of clients")
            {
                string[] datas = boughtProd
                    .Split("-,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string name = datas[0];
                string product = datas[1];
                int quantity = int.Parse(datas[2]);

                if (!priceList.ContainsKey(product))
                {
                    boughtProd = Console.ReadLine();
                    continue;
                }

                Customer customer = new Customer();

                customer.Name = name;
                customer.ShopingList = new Dictionary<string, int>
                {
                    [product] = quantity
                };
                customer.Bill = quantity * priceList[product];
                
                //Customer customer = new Customer()
                //{
                //    Name = name,
                //
                //    ShopingList = new Dictionary<string, int>
                //    {
                //        [product] = quantity
                //    },
                //
                //    Bill = quantity * priceList[product]
                //};

                if (!customersProducts.Exists(x => x.Name == customer.Name))
                {
                    customersProducts.Add(customer);
                }
                else
                {
                    Customer existCustomers = customersProducts.First(c => c.Name == name);

                    if (!(existCustomers.ShopingList.ContainsKey(product)))
                    {
                        existCustomers.ShopingList.Add(product, quantity);
                        existCustomers.Bill += customer.Bill;
                    }
                    else
                    {
                        existCustomers.ShopingList[product] += quantity;
                        existCustomers.Bill += customer.Bill;
                    }

                }

                boughtProd = Console.ReadLine();

            }
            decimal totalPrice = 0M;
            foreach (var item in customersProducts.OrderBy(a=>a.Name).ThenBy(b=>b.Bill))
            {
                Console.WriteLine($"{item.Name}");

                foreach (var items in item.ShopingList)
                {
                    Console.WriteLine($"-- {items.Key} - {items.Value}");
                }
                Console.WriteLine($"Bill: {item.Bill:F2}");
                totalPrice += item.Bill;
            }
            Console.WriteLine($"Total bill: {totalPrice:F2}");

            
        }
    }
}
