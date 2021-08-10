using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
            Countries = new HashSet<Country>();
            Languages = new HashSet<Language>();
            SortBies = new HashSet<SortBy>();
            Sources = new HashSet<Source>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(255)]

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        [InverseProperty("Users")]
        public virtual State State { get; set; }
        [InverseProperty(nameof(Article.User))]
        public virtual ICollection<Article> Articles { get; set; }
        [InverseProperty(nameof(Author.User))]
        public virtual ICollection<Author> Authors { get; set; }
        [InverseProperty(nameof(Category.User))]
        public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty(nameof(Country.User))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(Language.User))]
        public virtual ICollection<Language> Languages { get; set; }
        [InverseProperty(nameof(SortBy.User))]
        public virtual ICollection<SortBy> SortBies { get; set; }
        [InverseProperty(nameof(Source.User))]
        public virtual ICollection<Source> Sources { get; set; }
    }
}
