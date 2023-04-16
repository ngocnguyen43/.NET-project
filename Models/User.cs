namespace WebAPI.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class User : AbstractModel
    {
        [StringLength(maximumLength: 56, MinimumLength = 5)]
        public string Fullname { get; set; }
        [Required, EmailAddress]
        [StringLength(maximumLength: 56, MinimumLength = 5)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
