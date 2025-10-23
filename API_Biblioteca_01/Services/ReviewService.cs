
using Microsoft.EntityFrameworkCore;
using API_Biblioteca_01.Models;

namespace API_Biblioteca_01.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las reseñas
        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.User)
                .ToListAsync();
        }

        // Obtener reseña por ID
        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Obtener reseñas por libro
        public async Task<IEnumerable<Review>> GetByBookIdAsync(int bookId)
        {
            return await _context.Reviews
                .Where(r => r.BookId == bookId)
                .Include(r => r.User)
                .ToListAsync();
        }

        // Obtener reseñas por usuario
        public async Task<IEnumerable<Review>> GetByUserIdAsync(int userId)
        {
            return await _context.Reviews
                .Where(r => r.UserId == userId)
                .Include(r => r.Book)
                .ToListAsync();
        }

        // Crear reseña
        public async Task<Review> CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        // Actualizar reseña
        public async Task<bool> UpdateAsync(Review review)
        {
            var existingReview = await _context.Reviews.FindAsync(review.Id);
            if (existingReview == null)
                return false;

            existingReview.Rating = review.Rating;
            existingReview.Comment = review.Comment;


            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar reseña
        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
