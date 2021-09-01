using PolicyStoreWebApi.Interfaces;

namespace PolicyStoreWebApi.Models
{
    public class PolicyStoreDataBaseSettings : IPolicyStoreDatabaseSettings
    {
        public string PolicyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
