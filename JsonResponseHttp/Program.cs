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
            var longest = authorName!.Split().OrderByDescending(s => s.Length).First();
            var authorsJson = Get(_authorUrl + authorName);
            var authors = JsonSerializer.Deserialize<RootAuthor>(authorsJson);

            if (authors!.numFound <= 0 || authors.docs.All(d => d.work_count <= 0))
            {
                Console.WriteLine("Author not found!!");
                return;
            }
            Console.WriteLine();

            var author = authors.docs.OrderByDescending(d => d.work_count)
                .First(d => d.work_count >= 1 && d.name.Contains(longest!, StringComparison.OrdinalIgnoreCase));
            var booksJson = Get(_authorBooksUrl + author.key + "/works.json");
            var books = JsonSerializer.Deserialize<RootBooks>(booksJson);

            Console.WriteLine($"Books: ({books?.entries.Count}) \nTop work: {author.top_work}\n");

            foreach (var book in books!.entries)
            {
                Console.WriteLine(book.title);
            }
            Console.WriteLine();

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

    // AUTHOR MODEL
    public class Doc
    {
        public string key { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<string> alternate_names { get; set; }
        public string birth_date { get; set; }
        public string top_work { get; set; }
        public int work_count { get; set; }
        public List<string> top_subjects { get; set; }
        public object _version_ { get; set; }
    }

    public class RootAuthor
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public List<Doc> docs { get; set; }
    }

    // AUTHOR BOOKS MODEL
    public class Author
    {
        public Author author { get; set; }
        public Type type { get; set; }
    }

    public class Author2
    {
        public string key { get; set; }
    }

    public class Created
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Entry
    {
        public object description { get; set; }
        public List<Link> links { get; set; }
        public string title { get; set; }
        public List<int> covers { get; set; }
        public List<string> subject_places { get; set; }
        public List<string> subjects { get; set; }
        public List<string> subject_people { get; set; }
        public string key { get; set; }
        public List<Author> authors { get; set; }
        public List<Excerpt> excerpts { get; set; }
        public Type type { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public LastModified last_modified { get; set; }
        public string first_publish_date { get; set; }
        public string subtitle { get; set; }
    }

    public class Excerpt
    {
        public string excerpt { get; set; }
        public string comment { get; set; }
        public Author author { get; set; }
    }

    public class LastModified
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Link
    {
        public string title { get; set; }
        public string url { get; set; }
        public Type type { get; set; }
        public string self { get; set; }
        public string author { get; set; }
        public string next { get; set; }
    }

    public class RootBooks
    {
        public Link links { get; set; }
        public int size { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Type
    {
        public string key { get; set; }
    }




}