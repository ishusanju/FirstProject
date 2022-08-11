namespace APIExampleForMongoDb.Model
{
    public interface IEmployeeDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}
