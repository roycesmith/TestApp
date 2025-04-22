using System.ComponentModel.DataAnnotations;

namespace TestApp.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public int DepartmentId { get; set; } = 0;
    public string FullName => FirstName + " " + LastName;
}
