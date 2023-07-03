using Album.Api.Controllers;
using Album.Api.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Api.Tests
{
    public class AlbumService_Tests
    {

        [Fact]
        public void GetAlbums_NoInput_ReturnAllEntires()
        {
            var testcontext = new AlbumContext();
            var albumservice = new AlbumService(testcontext);
            var res = albumservice.GetAlbums();
            Assert.IsAssignableFrom<List<Album>>(res);
        }
        [Fact]
        public void PostAlbums_Alb5Input_RetrunObj()
        {
            var testcontext = new AlbumContext();
            var albumservice = new AlbumService(testcontext);
            var result = albumservice.PostAlbum(new Album(9999999,"album5", "grant Kirkhop", "nah"));
            albumservice.DeleteAlbum(9999999);
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            
        }
        [Fact]
        public void getAlbum_CorrectInput_ReturnRow()
        {
            var testcontext = new AlbumContext();
            var albumservice = new AlbumService(testcontext);
            var res = albumservice.PostAlbum(new Album(9999999, "album5", "grant Kirkhop", "nah")).Value;
            Assert.True(albumservice.GetAlbum(9999999).Name == new Album(9999999, "album5", "grant Kirkhop", "nah").Name);
            albumservice.DeleteAlbum(9999999);
        }
        [Fact]
        public void getAlbum_InvalidInput_ReturnNotfound()
        {
            var testcontext = new AlbumContext();
            var albumservice = new AlbumService(testcontext);
            Assert.True(albumservice.GetAlbum(0)==null);
        }
        [Fact]
        public void DeleteAlbum_InvalidInput_ReturnNotfound()
        {
            var testcontext = new AlbumContext();
            var albumservice= new AlbumService(testcontext);
            Assert.IsAssignableFrom<NotFoundResult>(albumservice.DeleteAlbum(0));
        }
    }
}
