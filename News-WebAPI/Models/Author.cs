using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("AuthorID")]
        public int AuthorId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("Authors")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Authors")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Article.Author))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
