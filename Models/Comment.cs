namespace Blog.Models;

public class Comment
{
    public int Id { get; set; }
   
    public string? Content { get; set; }
    public DateTime? Created { get; set; } = DateTime.Now;
    public DateTime? Updated { get; set; } = DateTime.Now;
   

    public int ArticleId { get; set; }
    public Article? Article { get; set; }


    public Comment() { }

}
