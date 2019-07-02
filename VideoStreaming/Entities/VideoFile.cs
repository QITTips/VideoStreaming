using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreaming.Entities
{
    public class VideoFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        [Display(Name = "File")]
        public byte[] data { get; set; }
    }
}
