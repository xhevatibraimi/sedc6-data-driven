﻿using MM.BusinessLayer.Contracts;
using MM.BusinessLayer.Providers;
using System.Web.Http;

namespace MM.WebApi.Controllers
{
    [RoutePrefix("albums")]
    public class AlbumsController: ApiController
    {
        private readonly IAlbumsProvider _albumsProvider;

        public AlbumsController(IAlbumsProvider albumsProvider)
        {
            _albumsProvider =albumsProvider
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll(int skip = 0,  int take =100)
        {
            return Ok(_albumsProvider.GetAll(skip, take));
        }

        [HttpGet]
        [Route("~/album-by-song/{songId:min(1)}")]
        public IHttpActionResult GetAll(int songId)
        {
            return Ok(_albumsProvider.GetAlbumBySongId(songId));
        }
    }
}