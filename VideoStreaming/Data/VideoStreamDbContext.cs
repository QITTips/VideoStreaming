using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreaming.Entities;

namespace VideoStreaming.Data
{
    public class VideoStreamDbContext : DbContext
    {
        public VideoStreamDbContext(DbContextOptions<VideoStreamDbContext> options)
        : base(options)
        {

        }

        public DbSet<VideoFile> VideoFile { get; set; }
    }
}
