using Hotel.DAO.HotelService;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelServiceImpl
{
    public class ConnectionServiceImpl<T> : IConnectionService<T>
    {
        private readonly IConfiguration _config;
        public ConnectionServiceImpl(IConfiguration config)
        {
            this._config = config;
        }
        public IMongoCollection<T> GetMongoCollection(string collectionName)
        {
            var client = new MongoClient(_config.GetConnectionString("HotelDB"));
            var database = client.GetDatabase("HotelDB");
            return database.GetCollection<T>(collectionName);
        }
    }
}
