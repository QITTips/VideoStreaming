using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VideoStreaming.Data;
using VideoStreaming.Models;

namespace VideoStreaming.Controllers
{
    public class HomeController : Controller
    {
        private readonly VideoStreamDbContext _context;
        public List<int> ListVideos { get; set; }
        public HomeController(VideoStreamDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ListVideos = _context.VideoFile.Select(i => i.Id).ToList();
            return View(ListVideos);
        }
 
        public IActionResult Upload()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
