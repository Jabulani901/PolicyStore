using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PolicyStoreWebApi.Models
{
    public class Policy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 
        public string PolicyName { get; set; }
        public string PolicyNumber { get; set; }
        public bool Acknowledgement { get; set; }
    }
}
