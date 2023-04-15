using Newtonsoft.Json;

namespace WebAPI.Models
{
    public abstract class AbstractModel
    {
        [JsonProperty]
        [StringLength(maximumLength: 36, MinimumLength = 36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}
