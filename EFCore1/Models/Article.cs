using System.Text.Json.Serialization;

namespace EFCore1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required string Text { get; set; }

        //1-*
        [JsonIgnore]
        public Blog Blog { get; set; }

        //*-*
        public required ICollection<User> Athors { get; set; }
    }
}
