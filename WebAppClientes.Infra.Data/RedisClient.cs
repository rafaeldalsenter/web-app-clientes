using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppClientes.Infra.Data
{
    public class RedisClient
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisClient(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public void Add<T>() where T : class
        {
        }

        public void Update<T>() where T : class
        {
        }

        public void Delete<T>() where T : class
        {
        }
    }
}