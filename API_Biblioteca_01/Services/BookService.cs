
using API_Biblioteca_01.Interfaces;
using API_Biblioteca_01.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca_01.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        // 📚 Obtener todos los libros con usuario y reseñas
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.User)
                .Include(b => b.Reviews)
                .ToListAsync();
        }

        // 🔍 Obtener libro por ID
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.User)
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // ➕ Crear libro
        public async Task<Book> CreateAsync(Book book)
        {
            book.CreatedAt = DateTime.Now;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        // ✏️ Actualizar libro
        public async Task<bool> UpdateAsync(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null)
                return false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.CoverImageUrl = book.CoverImageUrl;
            existingBook.UpdatedAt = DateTime.Now;

            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();
            return true;
        }

        // ❌ Eliminar libro
        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        // 📚 Listar libros por usuario
        public async Task<IEnumerable<Book>> GetByUserIdAsync(int userId)
        {
            return await _context.Books
                .Where(b => b.UserId == userId)
                .Include(b => b.Reviews)
                .ToListAsync();
        }
    }
}
