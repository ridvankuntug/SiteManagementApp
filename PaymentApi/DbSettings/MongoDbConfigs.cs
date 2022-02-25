namespace PaymentApi.DbSettings
{
    public class MongoDbConfigs : IPaymentDatabaseSettings
    {
        public string CollectionNameCreditCard { get; set; }
        public string CollectionNamePaymentHistory { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPaymentDatabaseSettings
    {
        string CollectionNameCreditCard { get; set; }
        string CollectionNamePaymentHistory { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
