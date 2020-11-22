using EQUIZY.Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.DataMongoDB.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        private readonly IMongoDatabase _db;

        public DatabaseSettings(IOptions<Settings> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Composer> Composers => _db.GetCollection<Composer>("Composers");
    }
}
