using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Album.Api;

namespace Album.Api.Controllers
{
    [Route("api/Album")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumContext _context;
        IAlbumService _albumService;

        public AlbumsController(AlbumContext context,IAlbumService service)
        {
            _context = context;
            _albumService = service;
        }

        // GET: api/Albums
        [HttpGet]
        public IActionResult GetAlbums()
        {
            if (_context.Albums == null)
            {
                return NotFound();
            }
            return Accepted(_albumService.GetAlbums());
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            var result =  _albumService.GetAlbum(id);

            if (result == null)
            {
                return NotFound();
            }

            return Accepted(result);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAlbum(int id, Album album)
        {
            if (id != album.ID)
            {
                return BadRequest();
            }

            return _albumService.PutAlbum(id, album);
            
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            if (album == null)
            {
                return Problem("Entity set 'AlbumContext.Albums'  is null.");
            }
            else { return Accepted(_albumService.PostAlbum(album)); }
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            return  _albumService.DeleteAlbum(id);
        }

        
    }
}
