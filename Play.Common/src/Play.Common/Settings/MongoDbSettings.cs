namespace Play.Common.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; init; }

        public int Port { get; init; }

        public string collectionString => $"mongodb://{Host}:{Port}";
    }
}