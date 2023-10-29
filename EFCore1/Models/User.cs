namespace EFCore1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateOnly? Birthday { get; set; }

        //1-1
        public UserSettings? UserSettings { get; set; }

        //*-*
        public ICollection<Blog> BlogSubscribsions { get; set; } = new List<Blog>();

        //*-*
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
