using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static string stringPath = "../../../Datasets/";

        public static IMapper mapper;

        public static void Main()
        {
            var context = new ProductShopContext();



            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var xmlUser = File.ReadAllText($"{stringPath}users.xml");
            //Console.WriteLine(ImportUsers(context, xmlUser));

            //var xmlProduct = File.ReadAllText($"{stringPath}products.xml");
            //Console.WriteLine(ImportProducts(context, xmlProduct));

            //var xmlCategory = File.ReadAllText($"{stringPath}categories.xml");
            //Console.WriteLine(ImportCategories(context, xmlCategory));

            //var xmlCategoryProduct = File.ReadAllText($"{stringPath}categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, xmlCategoryProduct));

            //var getProductRange = GetProductsInRange(context);
            //File.WriteAllText($"{stringPath}products-in-range.xml", getProductRange);
            //Console.WriteLine(getProductRange);

            //var getSoldProduct = GetSoldProducts(context);
            //File.WriteAllText($"{stringPath}users-sold-products.xml", getSoldProduct);
            //Console.WriteLine(getSoldProduct);

            //var getCategoriesInfo = GetCategoriesByProductsCount(context);
            //File.WriteAllText($"{stringPath}categories-by-products.xml", getCategoriesInfo);
            //Console.WriteLine(getCategoriesInfo);

            //var getUsersProducts = GetUsersWithProducts(context);
            //File.WriteAllText($"{stringPath}users-and-products.xml", getUsersProducts);
            //Console.WriteLine(getUsersProducts);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            mapper = Helper.InicializeMapper();

            var usersDto = Helper.XmlDeserialise<ImportUserDto[]>(inputXml, "Users");

            var users = mapper.Map<ICollection<User>>(usersDto);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            mapper = Helper.InicializeMapper();

            var productsDto = Helper.XmlDeserialise<ImportProductDto[]>(inputXml, "Products");

            var products = mapper.Map<ICollection<Product>>(productsDto);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            mapper = Helper.InicializeMapper();

            var categoryDto = Helper.XmlDeserialise<ImportCategoryDto[]>(inputXml, "Categories");

            var categories = mapper.Map<ICollection<Category>>(categoryDto.Where(c => c.Name != null));

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var mapper = Helper.InicializeMapper();

            var productsCategoriesDto = Helper.XmlDeserialise<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            var productsCategories = new List<CategoryProduct>();

            foreach (var productCategoryDto in productsCategoriesDto)
            {
                if (context.Categories.Any(c => c.Id == productCategoryDto.CategoryId) && context.Products.Any(p => p.Id == productCategoryDto.ProductId))
                {
                    var productCategory = mapper.Map<CategoryProduct>(productCategoryDto);
                    productsCategories.Add(productCategory);
                }
            }

            context.AddRange(productsCategories);
            context.SaveChanges();

            return $"Successfully imported {productsCategories.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            var productsInRange = context.Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            var stringRepresentation = Helper.XmlSerialise(productsInRange, "Products");

            return stringRepresentation;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.BuyerId != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(u=>new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Where(x=>x.BuyerId!=null).Select(sp=>new ExportProductInfoDto
                    {
                        Name = sp.Name,
                        Price = sp.Price
                    }).ToArray()
                })
                .ToArray();

            var stringRepresentation = Helper.XmlSerialise(users, "Users");

            return stringRepresentation;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var category = context.Categories
                .Select(c=>new ExportCategoryInfoDto
                {
                    Name = c.Name,
                     Count = c.CategoryProducts.Count,
                     AveragePrice = c.CategoryProducts.Average(p=>p.Product.Price),
                     TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var stringRepresentation = Helper.XmlSerialise(category, "Categories");

            return stringRepresentation;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                .ToArray()
                .Select(u => new ExportUserInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProduct
                    {
                        Count = u.ProductsSold.Where(x => x.BuyerId != null).Count(),
                        Products = u.ProductsSold.Where(x => x.BuyerId != null).Select(x => new ExportProductInfoDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();

            var user = new ExportUserCountDto
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            string stringRepresentation = Helper.XmlSerialise(user, "Users");

            return stringRepresentation;


        }
    }
}