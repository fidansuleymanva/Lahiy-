namespace ShopGrids.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength: 100, ErrorMessage = "FullName is too long!")]
        public string FullName { get; set; }
    }
}
