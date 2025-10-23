using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Biblioteca_01.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Relaciones
        public ICollection<Books>? Books { get; set; }
        public ICollection<Reviews>? Reviews { get; set; }
    }
}

