using MongoDB.Bson;
using System;
using System.IO;

namespace MongoXmlTutorial
{
    class Program
    {
        private const ConsoleColor ErrorColor = ConsoleColor.Red;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ErrorColor;
                Console.WriteLine("Arguments are empty. Input XML file cannot be found.");
                return;
            }

            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ErrorColor;
                Console.WriteLine($"File {filePath} cannot be found.");
                return;
            }

            string fileData = File.ReadAllText(filePath);
            var catalog = XmlDeserializer.Deserialize<Catalog>(fileData);

            /// Insert all books into "books" collection
            var mongoClient = new MongoDbClient("library");
            foreach(var book in catalog.Books)
            {
                mongoClient.InsertObject<Book>("books", book).GetAwaiter().GetResult();
            }

            var result = mongoClient.GetAllItems<Book>("books", new BsonDocument("Genre", "Fantasy")).GetAwaiter().GetResult();
            foreach(var r in result)
            {
                Console.WriteLine($"Book is: {r.Title}, by Author: {r.Author}");
            }

            Console.WriteLine();
            Console.WriteLine();

            var mongoBookClient = new MongoBookDbClient();
            result = mongoBookClient.GetAllBooksByAuthor("O'Brien, Tim").GetAwaiter().GetResult();
            foreach (var r in result)
            {
                Console.WriteLine($"Book is: {r.Title}, by Author: {r.Author}");
            }
        }
    }
}
