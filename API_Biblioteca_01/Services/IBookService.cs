using API_Biblioteca_01.Models;

namespace API_Biblioteca_01.Interfaces
{
    public interface IBookService
    {
        // 📚 Listar todos los libros
        Task<IEnumerable<Book>> GetAllAsync();

        // 🔍 Obtener un libro por Id
        Task<Book?> GetByIdAsync(int id);

        // ➕ Crear un nuevo libro
        Task<Book> CreateAsync(Book book);

        // ✏️ Actualizar un libro existente
        Task<bool> UpdateAsync(Book book);

        // ❌ Eliminar un libro
        Task<bool> DeleteAsync(int id);

        // 📚 Listar libros por usuario
        Task<IEnumerable<Book>> GetByUserIdAsync(int userId);
    }
}
