using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Mobile { get; set; }
    [Required]
    public string State { get; set; }
    [Required] 
    public string City { get; set; }
    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}
