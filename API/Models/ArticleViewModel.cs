using Data.Entities;

namespace WebApp.Models
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
            ArticleDescriptions = new List<ArticleDescriptionsViewModel>();
        }
        public int ArticleId { get; set; }
        public int Content { get; set; }
        public string Unit { get; set; }
        public List<ArticleDescriptionsViewModel> ArticleDescriptions { get; set; }
    }

    public class ArticleDescriptionsViewModel
    {
        public int ArticleDescriptionId { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
