namespace EFCore1.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable<BlogDto> Subscribtions { get; set; }
    }

    public class BlogDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
