using System.ComponentModel.DataAnnotations;

namespace PierresTreats.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [Display(Name = "Pick a User Name")]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and Confirmation must match.")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }
  }
}