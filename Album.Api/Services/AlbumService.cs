using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Album.Api;

public interface IAlbumService
{
    List<Album> GetAlbums();
    Album GetAlbum(int id);
    IActionResult PutAlbum(int id, Album album);
    CreatedAtActionResult PostAlbum(Album album);
    IActionResult DeleteAlbum(int id);
    bool AlbumExists(int id);
}

public class AlbumService : ControllerBase,IAlbumService
{
    private readonly AlbumContext _context;

    public AlbumService(AlbumContext context)
    {
        _context = context;
    }
    public List<Album> GetAlbums()
    {
        var res = _context.Albums.ToList();
        return res;
    }
    public Album GetAlbum(int id)
    {
        if (_context.Albums == null)
        {
            return null;
        }
        var album =  _context.Albums.Find(id);

        if (album == null)
        {
            return null;
        }
        return album;
    }
    public IActionResult PutAlbum(int id, Album album)
    {
        _context.Entry(album).State = EntityState.Modified;

        try
        {
            _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlbumExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    public CreatedAtActionResult PostAlbum(Album album)
    {
        if (_context.Albums == null)
        {
            return null;
        }
        _context.Albums.Add(album);
        _context.SaveChanges();
        var res = CreatedAtAction("GetAlbum", new { id = album.ID }, album);
        return res;
    }
    public IActionResult DeleteAlbum(int id)
    {
        if (_context.Albums == null)
        {
            return NotFound();
        }
        var album = _context.Albums.Find(id);
        if (album == null)
        {
            return NotFound();
        }

        _context.Albums.Remove(album);
        _context.SaveChangesAsync();

        return NoContent();
    }
    public bool AlbumExists(int id)
    {
        return (_context.Albums?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}
