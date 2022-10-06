using MongoDB.Driver;
using System;
using MongoDB.Bson;
using System.IO;
using NoSQLCRUDOperations.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace NoSQLCRUDOperations
{
    public class StartUp
    {
        static void Main()
        {
            var importArticle = File.ReadAllText($"../../../Datasets/Import/articles.json");

            var client = new MongoClient("mongodb://localhost:27017");
            //var db = client.GetDatabase("Articles");
            //var collection = db.GetCollection<Article>("articles");

            //var articlesDto = JsonConvert.DeserializeObject<ImportArticlesDto>(importArticle);

            //foreach (var articleDto in articlesDto.Articles)
            //{
            //    var a = new Article
            //    {
            //        Author = articleDto.Author,
            //        Date = DateTime.Parse(articleDto.Date),
            //        Name = articleDto.Name,
            //        Rating = int.Parse(articleDto.Rating)
            //    };

            //    collection.InsertOne(a);
            //}

            var sb = new StringBuilder();

            var condition = Builders<Article>.Filter.Eq(p => p.Name,"Name");
            
            
        }
    }
}
