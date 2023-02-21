using MCC75NET.Models;
using System.ComponentModel.DataAnnotations;

namespace MCC75NET.ViewModels;

public class EmployeeVM
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
    [Phone]
    public string? PhoneNumber { get; set; }
}
