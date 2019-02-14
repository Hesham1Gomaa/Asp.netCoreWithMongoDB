using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Asp.NetCoreWithMongoDB.Models
{
    public class Tasks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("title")]
        public string title { get; set; }

        [BsonElement("isDone")]
        public bool isDone { get; set; }

    }
}
