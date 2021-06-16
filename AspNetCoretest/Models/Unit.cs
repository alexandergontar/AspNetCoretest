using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoretest.Models
{
    public class Unit
    {
        int[] numb = {1,5,7,9,10 };
        void myIe() 
        {
            IEnumerator ie = numb.GetEnumerator();
            //return numb.GetEnumerator();            
        }
        enum Cars {tobik, bobik, mobik }
        public string sourceWebInt { get; set; } //Webinterface descr textfile
        public string sourceDesktopFile { get; set; } //Desktop descr textfile
        public string sourceXamarinFile { get; set; } // Xamarin mobile descr textfile
        public string sourceFile { get; set; } 
        public string sourceFile1 { get; set; }
        public string Firstrequest { get; set; }//cookies
        public string Usercomment { get; set; }//coocies
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public List<string> Authors { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
