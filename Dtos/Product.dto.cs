using Newtonsoft.Json;

namespace WebAPI.Dtos
{
    public class ProductDto
    {
        //[JsonProperty]
        [JsonIgnore]
        internal Guid Id { get; set; }
        [JsonProperty]
        public string productName { get; set; }
        [JsonProperty]
        public string description { get; set; }
        public decimal Price { get; set; }
        public float DiscountPercent { get; set; } = 0;
        public decimal Stock { get; set; }
    }
}
