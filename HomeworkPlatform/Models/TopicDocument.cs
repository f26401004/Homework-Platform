using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkPlatform.Models
{
    public class TopicDocument
    {
        [BsonId]
        public ObjectId TopicId { get; set; }
        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }


    }
}