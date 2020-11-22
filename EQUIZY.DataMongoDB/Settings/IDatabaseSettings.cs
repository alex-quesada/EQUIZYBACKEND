using EQUIZY.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EQUIZY.DataMongoDB.Settings
{
    public interface IDatabaseSettings
    {
        IMongoCollection<Composer> Composers { get; }
    }
}
