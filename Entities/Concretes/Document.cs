using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Document : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 

        [BsonElement("name")]
        public string Name { get; set; } 

        [BsonElement("path")]
        public string Path { get; set; } 

        [BsonElement("type")]
        public string Type { get; set; } 

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } 

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } 
        [BsonElement("__v")]
        public int Version { get; set; } 

    }
}
