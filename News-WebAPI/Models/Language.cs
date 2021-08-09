using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class Language
    {
        public Language()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("LanguageID")]
        public int LanguageId { get; set; }
        [StringLength(8)]
        public string LanguageCode { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("Languages")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Languages")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Article.Language))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
