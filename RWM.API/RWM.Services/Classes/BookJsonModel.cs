using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Classes
{
    public class BookJsonModel
    {
        public string Title { get; set; }
        public string Series { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Pages { get; set; }
        public string CoverImg { get; set; }
    }
}
