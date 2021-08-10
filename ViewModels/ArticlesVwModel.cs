using System;

namespace ViewModels
{
    public class ArticlesVwModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string UrltoArticle { get; set; }
        public string UrltoImage { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? Uptake { get; set; }
        public int? SourceId { get; set; }
        public int? CategoryId { get; set; }
        public int? CountryId { get; set; }
        public int? LanguageId { get; set; }
        public int? StateId { get; set; }
        public int? SortId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
