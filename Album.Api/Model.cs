using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Album.Api;
public class AlbumContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>().HasKey(_ => _.ID);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID = SaveState; Password = hrpkMKQ6b4RscWUW7A2F; Host = cnsd-db-600958609702.cwzqexj6zi9s.us-east-1.rds.amazonaws.com; port = 5432; Database = albumdatabase; Pooling = true");
        //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        //optionsBuilder.EnableSensitiveDataLogging();
    }
    public DbSet<Album> Albums { get; set; } = null!;
}

public class Album
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Artist { get; set; }
    public string ImageURL { get; set; }

    //constructors
    public Album() { }
    public Album(int id, string name) { Name = name; ID = id; }
    public Album(int id, string name,string artist) : this(id, name) => Artist = artist;
    public Album(int id, string name,string artist,string image):this(id, name) { Artist = artist; ImageURL = image; }
}