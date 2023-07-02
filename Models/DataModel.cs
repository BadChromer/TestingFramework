namespace Framework.Models
{
    public class DataModel
    {
        public class UserData
        {
            public string? firstName { get; set; }
            public string? lastName { get; set; }
            public int age { get; set; }
            public string? email { get; set; }
            public int salary { get; set; }
            public string? department { get; set; }
        }

        public class ConfigData
        {
            public string? MAIN_PAGE_URL { get; set; }
            public string? BROWSER_NAME { get; set; }
        }
    }
}