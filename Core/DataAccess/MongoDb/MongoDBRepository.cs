using MongoDB.Driver;
using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccess.MongoDB
{
    public class MongoEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoEntityRepositoryBase(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(TEntity entity)
        {
            var id = entity.GetType().GetProperty("Id").GetValue(entity);
            _collection.DeleteOne(Builders<TEntity>.Filter.Eq("_id", id));
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault();  // SingleOrDefault yerine FirstOrDefault kullanıldı
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _collection.Find(Builders<TEntity>.Filter.Empty).ToList()
                : _collection.Find(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            var id = entity.GetType().GetProperty("Id").GetValue(entity);
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            _collection.ReplaceOne(filter, entity);
        }
    }
}
