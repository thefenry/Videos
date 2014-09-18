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
        public HttpResponseMessage PostVideo(Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();

                //We always want to return a 201 code when a post is created instead of a generic 200. We also want to return a url/location
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = video.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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
        public HttpResponseMessage Delete(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Videos.Remove(video);
    
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
    }
}
