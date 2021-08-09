using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class State
    {
        public State()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
            Countries = new HashSet<Country>();
            Languages = new HashSet<Language>();
            SortBies = new HashSet<SortBy>();
            Sources = new HashSet<Source>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("StateID")]
        public int StateId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty(nameof(Article.State))]
        public virtual ICollection<Article> Articles { get; set; }
        [InverseProperty(nameof(Author.State))]
        public virtual ICollection<Author> Authors { get; set; }
        [InverseProperty(nameof(Category.State))]
        public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty(nameof(Country.State))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(Language.State))]
        public virtual ICollection<Language> Languages { get; set; }
        [InverseProperty(nameof(SortBy.State))]
        public virtual ICollection<SortBy> SortBies { get; set; }
        [InverseProperty(nameof(Source.State))]
        public virtual ICollection<Source> Sources { get; set; }
        [InverseProperty(nameof(User.State))]
        public virtual ICollection<User> Users { get; set; }
    }
}
