using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videos.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
        public Video Get(int id)
        {
            var video = db.Videos.Find(id);
            
            if (video == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return video;
        }

        // POST: api/Video
        public string Post(string value)
        {
            return value;
        }

        // PUT: api/Video/5
        public HttpResponseMessage PutVideo(int id, Video video)
        {
            if (ModelState.IsValid && id==video.Id)
            {
                db.Entry(video).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, video);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
