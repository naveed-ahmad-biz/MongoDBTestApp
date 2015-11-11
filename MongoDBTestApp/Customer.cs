using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBTestApp
{
    public class Customer
    {
        //required field to perform CRUD opertions on Bson or Binary Json
        [BsonElement("Id")]
        public ObjectId Id { get; set; }

        //C# 6.0 initializers
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "Doe";
        public DateTime Timestamp  { get; set; } = DateTime.UtcNow;
    }
}
