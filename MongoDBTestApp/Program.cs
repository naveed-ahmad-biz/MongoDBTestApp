using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates a MongoDB client from conn string
            var client = new MongoClient("mongodb://localhost");
            //gets the database within client
            var database = client.GetDatabase("customer");
            //gets the collection from the database
            var collection = database.GetCollection<Customer>("customers");
            //insert into database
            Task.WaitAll(InsertCustomer(collection));
            //find customer and print it
            Task.WaitAll(FindCustomer(collection));

        }

        static async Task InsertCustomer(IMongoCollection<Customer> collection)
        {
            await collection.InsertOneAsync(new Customer());
        }

        static async Task FindCustomer(IMongoCollection<Customer> collection)
        {
            //creates a filter to find Bson Document
            var filter = Builders<Customer>.Filter.Eq(c => c.FirstName, "John");
            //runs the query to find it
            var query = await collection.Find(filter).ToListAsync();
            //gets the customer
            var customer = query.FirstOrDefault();
            //displays the customer using C# 6.0 string formatter
            Console.WriteLine($"Customer {customer.FirstName} {customer.LastName} is found!");

        }
        
    }
}
