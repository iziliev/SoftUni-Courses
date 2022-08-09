using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            ////Use it before import all Query from 1 - 4
            ////-----------------------------------------
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            ////Query 1. Import Users
            //var userJson = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, userJson));

            ////Query 2. Import Products
            //var productJson = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, productJson));

            ////Query 3. Import Categories
            //var categoryJson = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, categoryJson));

            ////Query 4. Import Categories and Products
            //var categoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProducts));

            ////Query5. Export Products in Range
            //Console.WriteLine(GetProductsInRange(context));

            //Query 6. Export Sold Products
            //Console.WriteLine(GetSoldProducts(context));

            ////Query 7. Export Categories by Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            ////Query 8. Export Users and Products
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var mapper = Configuration.InicializeMapper();

            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var mapper = Configuration.InicializeMapper();

            var productsDto = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var mapper = Configuration.InicializeMapper();

            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(inputJson);
            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto)
                .Where(c => c.Name != null);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var mapper = Configuration.InicializeMapper();

            var categoryProductsDto = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductsDto);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //Query5. Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(e => new
                {
                    Name = e.Name,
                    Price = e.Price,
                    Seller = e.Seller.FirstName + " " + e.Seller.LastName
                })
                .ToArray();

            string stringRepresentation = JsonConvert.SerializeObject(products, Configuration.JsonFormatingForPrint());

            //File.WriteAllText("../../../Datasets/products-in-range.json", stringRepresentation);

            return stringRepresentation;
        }

        //Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(sp => sp.BuyerId != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(b => b.BuyerId != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName,
                    })
                })
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(users, Configuration.JsonFormatingForPrint());

            //File.WriteAllText("../../../Datasets/users-sold-products.json", stringRepresentation);

            return stringRepresentation;
        }

        //Query 7. Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(p => p.ProductsCount)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(categories, Configuration.JsonFormatingForPrint());

            //File.WriteAllText("../../../Datasets/categories-by-products.json", stringRepresentation);

            return stringRepresentation;
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(sp => sp.BuyerId != null))
                .ToArray()
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Where(ps=>ps.BuyerId!=null).Count(),
                        Products = u.ProductsSold
                        .Where(sp => sp.BuyerId != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();
               
            var newUsers = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var stringRepresentation = JsonConvert.SerializeObject(newUsers, Configuration.JsonFormatingForPrint());

           //ProductsSoldFile.WriteAllText("../../../Datasets/users-and-products.json", stringRepresentation);

            return stringRepresentation;
        }
    }
}