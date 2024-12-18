using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace admındeneme
{
    public class CustomerDal : ICustomerDal
    {
        private readonly IMongoCollection<Customer> _customers;

        // Yapıcı metod: connectionString ve databaseName parametreleri alıyor
        public CustomerDal(string connectionString, string databaseName)
        {
            // MongoDB client ve veritabanı nesnesi oluşturuluyor
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _customers = database.GetCollection<Customer>("customers");
        }

        // Müşterileri filtreli şekilde getiren metot
        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            if (filter == null)
            {
                return _customers.Find(new BsonDocument()).ToList();
            }
            else
            {
                return _customers.Find(filter).ToList();
            }
        }

        // Tek bir müşteri getiren metot
        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            return _customers.Find(filter).FirstOrDefault();
        }

        // Müşteri ekleme metodu
        public void Add(Customer entity)
        {
            _customers.InsertOne(entity);
        }

        // Müşteri güncelleme metodu
        public void Update(Customer entity)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, entity.Id);
            _customers.ReplaceOne(filter, entity);
        }

        // Müşteri silme metodu
        public void Delete(Customer entity)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, entity.Id);
            _customers.DeleteOne(filter);
        }
    }
}
