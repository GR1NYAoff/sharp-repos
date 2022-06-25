
namespace JsonResponseHttp.Responses
{
    public class RootBooksEx3
    {
        public LinksEx1 links { get; set; }
        public int size { get; set; }
        public List<EntryEx3> entries { get; set; }
    }

    public class AuthorEx3
    {
        public object type { get; set; }
        public AuthorEx3 author { get; set; }
    }
    
    public class DescriptionEx3
    {
        public string type { get; set; }
        public string value { get; set; }
    }
    
    public class EntryEx3
    {
        public Type type { get; set; }
        public string title { get; set; }
        public List<string> subjects { get; set; }
        public List<AuthorEx3> authors { get; set; }
        public string key { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public CreatedEx1 created { get; set; }
        public LastModifiedEx1 last_modified { get; set; }
        public List<string> subject_places { get; set; }
        public List<int> covers { get; set; }
        public List<LinksEx1> links { get; set; }
        public List<string> subject_times { get; set; }
        public DescriptionEx3 description { get; set; }
    }
   
}
