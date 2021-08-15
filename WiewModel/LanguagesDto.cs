using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LanguagesDto
    {
        public int LanguageId { get; set; }
        //[StringLength(8)]
        public string LanguageCode { get; set; }
        //[StringLength(100)]
        public string Name { get; set; }
        //[Column("StateID")]
        public int? StateId { get; set; }
        //[Column("UserID")]
        public int? UserId { get; set; }
    }
}
