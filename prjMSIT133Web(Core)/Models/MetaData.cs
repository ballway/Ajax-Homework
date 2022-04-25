using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT133Site.Models
{
    public class MemberMetadata
    {
        public int MemberId { get; set; }

        [DisplayName("姓名")]

        public string Name { get; set; }
        [DisplayName("電子郵件")]
        public string Email { get; set; }
        [DisplayName("年紀")]
        public int? Age { get; set; }
        [DisplayName("圖檔")]
        public string FileName { get; set; }
    }

  public class AddressMetadata
    {
        [DisplayName("城市")]
        public string City { get; set; }
        [DisplayName("鄉鎮區")]
        public string SiteId { get; set; }
        [DisplayName("路名")]
        public string Road { get; set; }
    }
}
