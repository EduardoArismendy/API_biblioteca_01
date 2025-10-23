using System;
using System.Collections.Generic;

namespace API_Biblioteca_01.Models;

public partial class Book
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? PublicationYear { get; set; }

    public string? CoverImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User User { get; set; } = null!;
}
