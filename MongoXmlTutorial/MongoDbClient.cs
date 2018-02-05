using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoXmlTutorial
{
    public class MongoDbClient
    {
        /// <summary>
        /// Default connection string. Should be in configuration for non trivial application
        /// </summary>
        private const string ConnectionString = "mongodb://localhost:27017/";

        protected IMongoDatabase _mongoDatabase;

        public MongoDbClient(string databaseName)
        {
            _mongoDatabase = new MongoClient(ConnectionString).
                GetDatabase(databaseName);
        }

        /// <summary>
        /// Inserts one item into given collection
        /// </summary>
        /// <typeparam name="T">Item type to inisert</typeparam>
        /// <param name="collectionName">Collection name in the mongo DB</param>
        /// <param name="item">item to insert</param>
        public async Task InsertObject<T>(string collectionName, T item)
        {
            await _mongoDatabase.
                GetCollection<T>(collectionName).
                InsertOneAsync(item);
        }

        /// <summary>
        /// Finds all items based on filter expression
        /// </summary>
        /// <typeparam name="T">Element type to search</typeparam>
        /// <param name="collectionName">Collection name</param>
        /// <param name="filter">filter expression</param>
        /// <returns>Found items enumeration</returns>
        public async Task<IList<T>> GetAllItems<T>(string collectionName, BsonDocument filter)
        {
            using (var resultCursor = await _mongoDatabase.
                                    GetCollection<T>(collectionName).
                                    FindAsync<T>(filter))
            {
                return await resultCursor.ToListAsync<T>();
            };
        }
    }
}
