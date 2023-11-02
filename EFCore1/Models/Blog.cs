using System.Text.Json.Serialization;

namespace EFCore1.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        //*-*

        [JsonIgnore]
        public ICollection<User>? Readers { get; set; }

        //1-*
        public ICollection<Article>? Articles { get; set; }
    }
}
