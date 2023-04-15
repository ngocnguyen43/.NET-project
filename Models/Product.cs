using Newtonsoft.Json;

namespace WebAPI.Models
{
    [Index(nameof(Id), IsUnique = true),]
    public class Product : AbstractModel
    {
        [JsonProperty]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(maximumLength: 56, MinimumLength = 10)]
        public string productName { get; set; }
        [JsonProperty]
        [StringLength(maximumLength: 56, MinimumLength = 20)]
        [Required(ErrorMessage = "Field is required")]
        public string description { get; set; }
        [JsonProperty]
        [StringLength(maximumLength: 56, MinimumLength = 20)]
        [Required(ErrorMessage = "Field is required")]
        public decimal Price { get; set; }
        public float DiscountPercent { get; set; } = 0;
        public decimal Stock { get; set; }
    }
}
