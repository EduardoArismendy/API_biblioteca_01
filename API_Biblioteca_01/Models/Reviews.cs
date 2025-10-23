using API_Biblioteca_01.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Biblioteca_01.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // 🔗 Relaciones
        [ForeignKey("BookId")]
        public Books? Book { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }
    }
}
