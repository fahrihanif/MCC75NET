using MCC75NET.Models;
using System.ComponentModel.DataAnnotations;

namespace MCC75NET.ViewModels;

public class RegisterVM
{
    public string NIK { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    [Display(Name = "Hiring Date")]
    public DateTime HiringDate { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Display(Name = "Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }
    public string Major { get; set; }
    [MaxLength(2), MinLength(2, ErrorMessage = "ex: S1/D3")]
    [Required(ErrorMessage = "Tidak Boleh Kosong ex: D3/S1")]
    public string Degree { get; set; }
    [Range(0, 4, ErrorMessage = "Inputan Harus Lebih dari {1} dan Kurang dari {2}")]
    public double GPA { get; set; }
    [Display(Name = "University Name")]
    public string UniversityName { get; set; }
    [DataType(DataType.Password)]
    [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
