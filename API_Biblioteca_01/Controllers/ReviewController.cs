using API_Biblioteca_01.Models;
using API_Biblioteca_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Biblioteca_01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // ============================================================
        // GET: api/review
        // Obtener todas las reseñas
        // ============================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAll()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        // ============================================================
        // GET: api/review/{id}
        // Obtener una reseña específica por ID
        // ============================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetById(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
                return NotFound(new { message = $"No se encontró la reseña con ID {id}" });

            return Ok(review);
        }

        // ============================================================
        // GET: api/review/book/{bookId}
        // Obtener reseñas por ID de libro
        // ============================================================
        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetByBookId(int bookId)
        {
            var reviews = await _reviewService.GetByBookIdAsync(bookId);
            return Ok(reviews);
        }

        // ============================================================
        // GET: api/review/user/{userId}
        // Obtener reseñas por ID de usuario
        // ============================================================
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetByUserId(int userId)
        {
            var reviews = await _reviewService.GetByUserIdAsync(userId);
            return Ok(reviews);
        }

        // ============================================================
        // POST: api/review
        // Crear nueva reseña
        // ============================================================
        [HttpPost]
        public async Task<ActionResult<Review>> Create([FromBody] Review review)
        {
            if (review == null)
                return BadRequest(new { message = "La reseña no puede ser nula" });

            if (review.Rating is < 1 or > 5)
                return BadRequest(new { message = "La calificación debe estar entre 1 y 5 estrellas" });

            var created = await _reviewService.CreateAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ============================================================
        // PUT: api/review/{id}
        // Actualizar reseña existente
        // ============================================================
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Review review)
        {
            if (review == null || id != review.Id)
                return BadRequest(new { message = "El ID no coincide o el cuerpo de la reseña es inválido" });

            var updated = await _reviewService.UpdateAsync(review);
            if (!updated)
                return NotFound(new { message = $"No se encontró la reseña con ID {id}" });

            return Ok(new { message = "Reseña actualizada correctamente" });
        }

        // ============================================================
        // DELETE: api/review/{id}
        // Eliminar reseña
        // ============================================================
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _reviewService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"No se encontró la reseña con ID {id}" });

            return Ok(new { message = "Reseña eliminada correctamente" });
        }
    }
}
