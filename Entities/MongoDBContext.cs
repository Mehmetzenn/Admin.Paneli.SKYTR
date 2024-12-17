using Entities.Concretes;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace DataAccess.Concretes
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            _database = new MongoClient(configuration["MongoDB:ConnectionString"])
                        .GetDatabase(configuration["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) => _database.GetCollection<T>(collectionName);
    }
}

