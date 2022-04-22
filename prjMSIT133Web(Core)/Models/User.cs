using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMSIT133Web_Core_.Models
{
    public class User
    {
        public string name { get; set; }
        public string age { get; set; }
        public string email { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
