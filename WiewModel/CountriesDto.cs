using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountriesDto
    {
        public int CountryId { get; set; }
        //[StringLength(10)]
        public string CountryCode { get; set; }
        //[StringLength(250)]
        public string Name { get; set; }
        //[Column("StateID")]
        public int? StateId { get; set; }
        //[Column("UserID")]
        public int? UserId { get; set; }
    }
}
