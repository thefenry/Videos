using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Models;

namespace Videos.Controllers
{
    public class VideosController : ApiController
    {
        private VideoDB db;

        public VideosController()
        {
            db = new VideoDB();
            db.Configuration.ProxyCreationEnabled = false;          
        }

        // GET: api/Video
        public IEnumerable<Video> Get()
        {
            return db.Videos;
        }

        // GET: api/Video/5
        public string Get(int id)
        {
            return "value " + id.ToString();
        }

        // POST: api/Video
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
