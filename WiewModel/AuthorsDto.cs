using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AuthorsDto
    {
        public int AuthorId { get; set; }
        //[StringLength(255)]
        public string Name { get; set; }
        //[StringLength(255)]
        public string LastName { get; set; }
        //[Column("StateID")]
        //public int? StateId { get; set; }
        ////[Column("UserID")]
        //public int? UserId { get; set; }

    }
}
