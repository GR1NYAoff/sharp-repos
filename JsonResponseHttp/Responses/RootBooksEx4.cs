
namespace JsonResponseHttp.Responses
{

    public class RootBooksEx4
    {
        public LinksEx2 links { get; set; }
        public int size { get; set; }
        public List<EntryEx4> entries { get; set; }
    }

    public class AuthorEx4
    {
        public object type { get; set; }
        public AuthorEx4 author { get; set; }
    }

    public class EntryEx4
    {
        public Type type { get; set; }
        public string title { get; set; }
        public List<string> subjects { get; set; }
        public List<string> subject_places { get; set; }
        public List<AuthorEx4> authors { get; set; }
        public List<int> covers { get; set; }
        public string key { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public CreatedEx1 created { get; set; }
        public LastModifiedEx1 last_modified { get; set; }
        public List<string> subject_times { get; set; }
        public List<string> subject_people { get; set; }
        public object description { get; set; }
        public string subtitle { get; set; }
        public int? id { get; set; }
    }
}
