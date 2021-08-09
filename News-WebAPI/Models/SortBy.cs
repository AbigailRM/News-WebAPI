using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    [Table("SortBy")]
    public partial class SortBy
    {
        public SortBy()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("SortID")]
        public int SortId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("SortBies")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("SortBies")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Article.Sort))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
