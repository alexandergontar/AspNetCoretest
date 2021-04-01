using System;
using System.Collections.Generic;
using System.IO;


using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoretest.Models
{
    public class Unit
    {
        public string sourceDesktopFile { get; set; }
        public string sourceFile { get; set; }
        public string sourceFile1 { get; set; }
        public string Firstrequest { get; set; }
        public string Usercomment { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public List<string> Authors { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
