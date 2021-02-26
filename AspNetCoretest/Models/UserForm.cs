using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoretest.Models
{
    public class UserForm
    {
        public string FirstName { get; set; }
        public string UserComment { get; set; }
        public Comments usercomments { get; set; }
    }
}
