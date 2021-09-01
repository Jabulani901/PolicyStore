namespace PolicyStoreWebApi.Interfaces
{
    public interface IPolicyStoreDatabaseSettings
    {
         string PolicyCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
    }
}
