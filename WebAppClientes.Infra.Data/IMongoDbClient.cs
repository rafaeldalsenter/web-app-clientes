using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebAppClientes.Domain;

namespace WebAppClientes.Infra.Data
{
    public interface IMongoDbClient
    {
        IQueryable<T> Get<T>() where T : BaseDomain;

        void InsertOne<T>(T obj) where T : BaseDomain;

        void ReplaceOne<T>(int id, T obj) where T : BaseDomain;

        void DeleteOne<T>(int id) where T : BaseDomain;
    }
}