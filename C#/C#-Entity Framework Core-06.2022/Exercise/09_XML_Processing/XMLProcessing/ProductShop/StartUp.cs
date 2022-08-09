using ProductShop.Data;
using ProductShop.DTO.Input;
using ProductShop.DTO.Output;
using ProductShop.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ProductShop.Data.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            ////1.Import Data

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            ////Query 1.Import Users
            //var usersXml = File.ReadAllText("../../../Datasets/Input/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXml));

            ////Query 2. Import Products
            //var productsXml = File.ReadAllText("../../../Datasets/Input/products.xml");
            //Console.WriteLine(ImportProducts(context,productsXml));

            ////Query 3.Import Categories
            //var categoriesXml = File.ReadAllText("../../../Datasets/Input/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            ////Query 4.Import Categories and Products
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/Input/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            ////2. Query and Export Data
            ////Query 5. Export Products In Range
            //Console.WriteLine(GetProductsInRange(context));

            ////Query 6. Export Sold Products
            //Console.WriteLine(GetSoldProducts(context));

            ////Query 7. Export Categories By Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            ////Query 8. Export Users and Products
            //Console.WriteLine(GetUsersWithProducts(context));

        }

        //Query 1.Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var usersDto = XmlConverter.Deserializer<InputUserDto>(inputXml, "Users");

            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var productsDto = XmlConverter.Deserializer<InputProductDto>(inputXml, "Products");

            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Query 3.Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var categoriesDto = XmlConverter.Deserializer<InputCategoryDto>(inputXml, "Categories");

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto)
                .Where(x => x.Name != "null");

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var categoryProductsDto = XmlConverter.Deserializer<InputCategoryProductDto>(inputXml, "CategoryProducts");

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductsDto);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(pb => new OutputProductWithBuyerDto
                {
                    Name = pb.Name,
                    Price = pb.Price,
                    BuyerName = pb.Buyer.FirstName + " " + pb.Buyer.LastName,
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(products, "Products");

            File.WriteAllText("../../../Datasets/Output/products-in-range.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.SoldProducts.Any(sp => sp.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.LastName)
                .Take(5)
                .Select(u => new OutputSoldProductsWithSeller
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.SoldProducts
                    .Select(sp => new OutputProductDto
                    {
                        Name = sp.Name,
                        Price = sp.Price
                    })
                    .ToArray()
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(users, "Users");

            File.WriteAllText("../../../Datasets/Output/users-sold-products.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new OutputCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(u => u.Count)
                .ThenBy(u => u.TotalRevenue)
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(categories, "Categories");

            File.WriteAllText("../../../Datasets/Output/categories-by-products.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new OutputCountUserDto
            {
                Count = context.Users.Where(u => u.SoldProducts.Any(sp => sp.BuyerId != null)).Count(),
                User = context.Users.Where(u => u.SoldProducts.Any(sp => sp.BuyerId != null))
                .Select(u => new OutputUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new OutputProductCountDto
                    {
                        Count = u.SoldProducts.Count,
                        Products = u.SoldProducts.Select(sp => new OutputProductDto
                        {
                            Name = sp.Name,
                            Price = sp.Price
                        })
                        .OrderByDescending(u => u.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray()
            };

            var stringRepresentation = XmlConverter.Serialize(users, "Users");

            return stringRepresentation;
        }
    }
}
