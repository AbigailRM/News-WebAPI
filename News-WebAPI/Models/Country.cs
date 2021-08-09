using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [StringLength(10)]
        public string CountryCode { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("Countries")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Countries")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Article.Country))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
