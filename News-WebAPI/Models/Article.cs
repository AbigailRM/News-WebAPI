using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace News_WebAPI.Models
{
    public partial class Article
    {
        [Key]
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [Column("AuthorID")]
        public int? AuthorId { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "text")]
        public string Content { get; set; }
        [Column("URLToArticle")]
        [StringLength(255)]
        public string UrltoArticle { get; set; }
        [Column("URLToImage")]
        [StringLength(255)]
        public string UrltoImage { get; set; }
        [Column("publishedAt", TypeName = "datetime")]
        public DateTime? PublishedAt { get; set; }
        public int? Uptake { get; set; }
        [Column("SourceID")]
        public int? SourceId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [Column("CountryID")]
        public int? CountryId { get; set; }
        [Column("LanguageID")]
        public int? LanguageId { get; set; }
        [Column("StateID")]
        public int? StateId { get; set; }
        [Column("SortID")]
        public int? SortId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Articles")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Articles")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Articles")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(LanguageId))]
        [InverseProperty("Articles")]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(SortId))]
        [InverseProperty(nameof(SortBy.Articles))]
        public virtual SortBy Sort { get; set; }
        [ForeignKey(nameof(SourceId))]
        [InverseProperty("Articles")]
        public virtual Source Source { get; set; }
        [ForeignKey(nameof(StateId))]
        [InverseProperty("Articles")]
        public virtual State State { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Articles")]
        public virtual User User { get; set; }
    }
}
