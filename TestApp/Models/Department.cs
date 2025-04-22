using System.ComponentModel.DataAnnotations;

namespace TestApp.Models;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}