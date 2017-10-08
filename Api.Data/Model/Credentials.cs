
using System.ComponentModel.DataAnnotations;

public class Credentials
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}