using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoStreaming.Data;
using VideoStreaming.Entities;

namespace VideoStreaming.Controllers
{
    public class UploadController : Controller
    {
        private readonly VideoStreamDbContext _context;

        public UploadController(VideoStreamDbContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            return View("Upload");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload()
        {
            if (HttpContext.Request.Form.Files[0] != null)
            {
                var file = HttpContext.Request.Form.Files[0];
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    VideoFile _video = new VideoFile();
                    _video.ContentType = file.ContentType;
                    _video.FileName = file.FileName;
                    _video.data = ms.ToArray();
                    _context.VideoFile.Add(_video);
                    _context.SaveChanges();
                }
            }

            return Redirect("~/");
        }
    }
}
