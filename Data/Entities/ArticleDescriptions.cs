using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class ArticleDescriptions
    {
        [Key]
        public int ArticleDescriptionId { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public Articles Article { get; set; }
    }
}
