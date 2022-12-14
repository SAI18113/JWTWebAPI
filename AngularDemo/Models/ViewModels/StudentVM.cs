using System.ComponentModel.DataAnnotations;

namespace AngularDemo.Models.ViewModels;

public class StudentVM
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    [Required]
    public string Mobile { get; set; }
    [Required]
    public string State { get; set; }
    [Required]
    public string City { get; set; }
}
