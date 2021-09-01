
using MongoDB.Driver;
using PolicyStoreWebApi.Interfaces;
using PolicyStoreWebApi.Models;
using System.Collections.Generic;

namespace PolicyStoreWebApi.Services
{
    public class PolicyService
    {
        private readonly IMongoCollection<Policy> _policy;

        public PolicyService(IPolicyStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _policy = database.GetCollection<Policy>(settings.PolicyCollectionName);
        }

        public List<Policy> Get() =>
            _policy.Find(policy => true).ToList();

        public Policy Get(string id) =>
            _policy.Find<Policy>(policy => policy.Id == id).FirstOrDefault();

        public Policy Create(Policy policy)
        {
            _policy.InsertOne(policy);
            return policy;
        }

        public void Update(string id, Policy policyIn) =>
            _policy.ReplaceOne(book => book.Id == id, policyIn);

        public void Remove(Policy policyIn) =>
            _policy.DeleteOne(policy => policy.Id == policyIn.Id);

        public void Remove(string id) =>
            _policy.DeleteOne(policy => policy.Id == id);
    }
}
