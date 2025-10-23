using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Biblioteca_01.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore] // Evita el ciclo
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [JsonIgnore] // Evita el ciclo
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
