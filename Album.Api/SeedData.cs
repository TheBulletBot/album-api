using System;
using System.Linq;

namespace Album.Api
{
    public static class DbInitializer
    {
        public static void Initialize(AlbumContext context)
        {
            context.Database.EnsureCreated();

            if (context.Albums.Any())
            {
                return;
            }

            var albums = new Album[] { 
                new Album{ID=1,Name="B&K_Re-jiggied",Artist="Grant Kirkhope",ImageURL="not found"},
                new Album{ID=2,Name="Album2",Artist="Grant Kirkhope",ImageURL="not found"},
                new Album{ID=3,Name="Album3",Artist="Grant Kirkhope",ImageURL="not found"},
                new Album{ID=4,Name="Album4",Artist="Grant Kirkhope",ImageURL="not found"}
            };
            foreach (Album album in albums) { context.Albums.Add(album); }
            context.SaveChanges();

        }
    }
}
