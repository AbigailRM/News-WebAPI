using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SourceDto
    {
        public int SourceId { get; set; }
        //[StringLength(30)]
        public string SourceName { get; set; }
        //[Column("StateID")]
        public int? StateId { get; set; }
        //[Column("UserID")]
        public int? UserId { get; set; }
    }
}
