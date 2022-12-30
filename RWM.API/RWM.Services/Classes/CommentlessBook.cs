using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Classes
{
    public class CommentlessBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public uint Pages { get; set; }
        public string CoverImgUrl { get; set; }
    }
}
