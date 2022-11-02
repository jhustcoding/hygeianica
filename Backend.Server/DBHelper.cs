using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Server.DataLayer
{
    public class DBHelper
    {
        private readonly IConfiguration _configuration;
        public DBHelper()
        {
            //_configuration = config;
        }

        public IMongoDatabase GetMongoDbInstance(string dbName)
        {
            //var connString = _configuration.GetConnectionString();
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var db = client.GetDatabase(dbName);
            return db;
        }

        private IMongoCollection<T> GetCollection<T>(string dbName, string collectionName)
        {
            return GetMongoDbInstance(dbName).GetCollection<T>(collectionName);
        }

        public List<T> GetAllDocuments<T>(string dbName, string collectionName)
        {
            var collection = GetCollection<T>(dbName, collectionName);
            return collection.Find(x => true).ToList();
        }

        public List<T> GetFilteredDocuments<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            return GetCollection<T>(dbName, collectionName).Find(filter).ToList();
        }

        public async Task UpdateDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> document)
        {
            await GetCollection<T>(dbName, collectionName).UpdateOneAsync(filter, document);
        }

        public async Task CreateDocument<T>(string dbName, string collectionName, T document)
        {
            await GetCollection<T>(dbName, collectionName).InsertOneAsync(document);
        }

        public async Task DeleteDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            await GetCollection<T>(dbName, collectionName).DeleteOneAsync(filter);
        }
    }
}