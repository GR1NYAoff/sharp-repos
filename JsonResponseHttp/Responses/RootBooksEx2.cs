
namespace JsonResponseHttp.Responses
{
    public class RootBooksEx2
    {
        public LinksEx2 links { get; set; }
        public int size { get; set; }
        public List<EntryEx2> entries { get; set; }
    }
    public class AuthorEx2
    {
        public AuthorEx2 author { get; set; }
        public object type { get; set; }
    }

    public class EntryEx2
    {
        public string description { get; set; }
        public List<int> covers { get; set; }
        public string key { get; set; }
        public List<AuthorEx2> authors { get; set; }
        public string title { get; set; }
        public List<string> subjects { get; set; }
        public Type type { get; set; }
        public string first_publish_date { get; set; }
        public FirstSentenceEx2 first_sentence { get; set; }
        public List<ExcerptEx2> excerpts { get; set; }
        public string location { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public CreatedEx1 created { get; set; }
        public LastModifiedEx1 last_modified { get; set; }
        public List<string> subject_places { get; set; }
        public List<string> subject_times { get; set; }
    }

    public class ExcerptEx2
    {
        public string excerpt { get; set; }
    }

    public class FirstSentenceEx2
    {
        public string type { get; set; }
        public string value { get; set; }
    }
    public class LinksEx2
    {
        public string self { get; set; }
        public string author { get; set; }
        public string next { get; set; }
    }

}
