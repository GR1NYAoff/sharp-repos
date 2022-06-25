using JsonResponseHttp.Responses;
using System.Net;
using System.Text.Json;

namespace JsonResponseHttp 
{
    public class Program
    {
        private const string _authorUrl = "https://openlibrary.org/search/authors.json?q=";
        private const string _authorBooksUrl = "https://openlibrary.org/authors/";

        public static void Main(string[] args)
        {
            Console.WriteLine("Author name:");

            var authorName = Console.ReadLine(); // J. K. Rowling | George R. R. Martin
            var authorsJson = Get(_authorUrl + authorName);
            var authors = JsonSerializer.Deserialize<RootAuthor>(authorsJson);

            if (authors!.numFound <= 0 || authors.docs.All(d => d.work_count <= 0))
            {
                Console.WriteLine("Author not found!!");
                return;
            }
            Console.WriteLine();

            var validAuthors = authors.docs.Where(d => d.work_count >= 1)
                .OrderByDescending(d => d.work_count)
                .DistinctBy(d => d.name).ToArray();

            Console.WriteLine($"Search results: ({validAuthors.Length})\n");
            for (int i = 0; i < validAuthors.Length; i++)
            {
                var booksJson = Get(_authorBooksUrl + validAuthors[i].key + "/works.json");
                var jsonObject = System.Text.Json.Nodes.JsonObject.Parse(booksJson);
                var entriesJsonArray = jsonObject?["entries"]?.AsArray();

                if (entriesJsonArray is null)
                    continue;

                Console.WriteLine($"{i + 1}) {validAuthors[i].name}");
                Console.WriteLine($"Total ({entriesJsonArray.Count})");
                Console.WriteLine($"Top work: {validAuthors[i].top_work}\n");

                foreach (var entry in entriesJsonArray!)
                {
                    Console.WriteLine(entry?["title"]);
                }
               
                
                Console.WriteLine("___________________________________________\n");
            }

            Console.ReadKey();
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

}