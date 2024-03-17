using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Articles
    {
        [Key]
        public int ArticleId { get; set; }
        public int Content { get; set; }
        public string Unit { get; set; }
        public List<ArticleDescriptions> ArticleDescriptions { get; set; }
    }
}
