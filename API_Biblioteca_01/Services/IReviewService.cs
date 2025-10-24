
using API_Biblioteca_01.Models;

namespace API_Biblioteca_01.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(int id);

        Task<IEnumerable<Review>> GetByBookIdAsync(int bookId);

        Task<IEnumerable<Review>> GetByUserIdAsync(int userId);

        Task<Review> CreateAsync(Review review);

        Task<bool> UpdateAsync(Review review);

        Task<bool> DeleteAsync(int id);
    }
}
