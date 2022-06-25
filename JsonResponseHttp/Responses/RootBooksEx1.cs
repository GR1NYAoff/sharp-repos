
namespace JsonResponseHttp.Responses
{
    // AUTHOR BOOKS MODEL
    [Obsolete]
    public class RootBooksEx1
    {
        public LinksEx1 links { get; set; }
        public int size { get; set; }
        public List<EntryEx1> entries { get; set; }
    }

    public class AuthorEx1
    {
        public AuthorEx1 author { get; set; }
        public Type type { get; set; }
    }

    public class CreatedEx1
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class EntryEx1
    {
        public object description { get; set; }
        public List<LinksEx1> links { get; set; }
        public string title { get; set; }
        public List<int> covers { get; set; }
        public List<string> subject_places { get; set; }
        public List<string> subjects { get; set; }
        public List<string> subject_people { get; set; }
        public string key { get; set; }
        public List<AuthorEx1> authors { get; set; }
        public List<ExcerptEx1> excerpts { get; set; }
        public Type type { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public CreatedEx1 created { get; set; }
        public LastModifiedEx1 last_modified { get; set; }
        public string first_publish_date { get; set; }
        public string subtitle { get; set; }
    }

    public class ExcerptEx1
    {
        public string excerpt { get; set; }
        public string comment { get; set; }
        public AuthorEx1 author { get; set; }
    }

    public class LastModifiedEx1
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class LinksEx1
    {
        public string title { get; set; }
        public string url { get; set; }
        public Type type { get; set; }
        public string self { get; set; }
        public string author { get; set; }
        public string next { get; set; }
    }

    public class Type
    {
        public string key { get; set; }
    }
}
