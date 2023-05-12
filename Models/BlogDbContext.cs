using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<User>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Article>()
                 
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId);
        }
    }

}
