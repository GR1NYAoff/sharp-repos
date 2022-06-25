
namespace JsonResponseHttp.Responses
{
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
}
