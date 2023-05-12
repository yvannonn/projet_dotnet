namespace Blog.Models
{
    public class Article
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string?  Author { get; set; }
        public string?  Content { get; set; }

        public  int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        //public Article() { }

    }
}
