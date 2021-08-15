using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoriesDto
    {
        public int CategoryId { get; set; }
        //[StringLength(50)]
        public string Name { get; set; }
        //[Column("StateID")]
        public int? StateId { get; set; }
        //[Column("UserID")]
        public int? UserId { get; set; }
    }
}
