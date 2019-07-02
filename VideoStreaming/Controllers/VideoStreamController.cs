using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreaming.Data;

namespace VideoStreaming.Controllers
{

    [Route("VideoStream/[action]")]
    public class VideoStreamController : Controller
    {
        private readonly VideoStreamDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;
        public VideoStreamController(VideoStreamDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpcontext = httpContextAccessor;
        }

        [HttpGet("{id}")]
        public void GetVideo(int id)
        {
            try
            {
                byte[] bytes = null;
                string contentType = "";
                string name = "";
                var video = _context.VideoFile.Where(i => i.Id == id).SingleOrDefault();

                if (video != null)
                {
                    contentType = video.ContentType;
                    bytes = video.data;
                    name = video.FileName;
                    _httpcontext.HttpContext.Response.Clear();
                    _httpcontext.HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + name);
                    _httpcontext.HttpContext.Response.ContentType = contentType;
                    _httpcontext.HttpContext.Response.Body.WriteAsync(bytes);
                }                
            }
            catch (Exception ex)
            {
                /// log esception
            }
        }

    }
}
