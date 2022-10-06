using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoSQLCRUDOperations.Models
{
    public class Article
    {
        [Key]
        public ObjectId Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
