using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Asp.NetCoreWithMongoDB.Models;
using Microsoft.Extensions.Configuration;

namespace Asp.NetCoreWithMongoDB.Service
{
    public class TaskService
    {
        private readonly IMongoCollection<Tasks> _Tasks;

        public TaskService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mytasklist_hesham"));
            var database = client.GetDatabase("mytasklist_hesham");
            _Tasks = database.GetCollection<Tasks>("tasks");
        }

        public List<Tasks> Get()
        {
            return _Tasks.Find(Tasks => true).ToList();
        }

        public Tasks Get(string id)
        {
            return _Tasks.Find<Tasks>(task => task._id == id).FirstOrDefault();
        }

        public Tasks Create(Tasks task)
        {
            _Tasks.InsertOne(task);
            return task;
        }
        public void Update(string id, Tasks taskIn)
        {
            _Tasks.ReplaceOne(task => task._id == id, taskIn);
        }

        public void Remove(Tasks taskIn)
        {
            _Tasks.DeleteOne(task => task._id == taskIn._id);
        }

        public void Remove(string id)
        {
            _Tasks.DeleteOne(task => task._id == id);
        }
    }
}
