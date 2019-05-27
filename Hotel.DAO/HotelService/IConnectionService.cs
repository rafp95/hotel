using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelService
{
    public interface IConnectionService<T>
    {
        IMongoCollection<T> GetMongoCollection(string collectionName);
    }
}
