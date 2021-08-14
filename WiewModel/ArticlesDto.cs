using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ArticlesDto
    {
        public int ArticleId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public int? AuthorId { get; set; }
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Content { get; set; }
        [StringLength(255)]
        public string UrltoArticle { get; set; }
        [StringLength(255)]
        public string UrltoImage { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? Uptake { get; set; }
        public int? SourceId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? LanguageId { get; set; }
        public int? StateId { get; set; }
        public int? SortId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
