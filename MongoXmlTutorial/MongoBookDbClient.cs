using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoXmlTutorial
{
    public class MongoBookDbClient : MongoDbClient
    {
        public MongoBookDbClient() :
            base("library")
        {
        }

        public async Task<IList<Book>> GetAllBooksByAuthor(string authorName)
        {
            using (var resultCursor = await _mongoDatabase.
                                                GetCollection<Book>("books").
                                                FindAsync<Book>(b => b.Author == authorName))
            {
                return await resultCursor.ToListAsync<Book>();
            }
        }
    }
}
