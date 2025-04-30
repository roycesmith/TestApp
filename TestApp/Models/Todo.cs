using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TestApp.Models;

public class Todo
{
    private const string V = "PersonId";
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public int Outstanding { get; set; } = 0;
    public DateTime Modified { get; set; } = DateTime.UtcNow;

    [ForeignKey("PersonId")]
    // add a navigation property to the person table
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public string? PersonName => Person?.FullName;
}
