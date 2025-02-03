using Microsoft.EntityFrameworkCore;

public class PolyBotDbContext : DbContext
{
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<Conversation> Conversations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=your_server;Database=PolyBotDB;Trusted_Connection=True;");
    }
}