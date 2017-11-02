using Microsoft.EntityFrameworkCore;

public class InMemoryContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
    {

    }

    public InMemoryContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
        }
    }


}