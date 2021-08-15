using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("SourceID")]
        public int SourceId { get; set; }
        [StringLength(30)]
        public string SourceName { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("Sources")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Sources")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Article.Source))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
