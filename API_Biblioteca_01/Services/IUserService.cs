using API_Biblioteca_01.Models;

namespace API_Biblioteca_01.Interfaces
{
    public interface IUserService
    {
        // 📋 Obtener todos los usuarios
        Task<IEnumerable<User>> GetAllAsync();

        // 🔍 Obtener un usuario por ID
        Task<User?> GetByIdAsync(int id);

        // ➕ Crear un nuevo usuario
        Task<User> CreateAsync(User user);

        // ✏️ Actualizar un usuario existente
        Task<bool> UpdateAsync(User user);

        // ❌ Eliminar un usuario
        Task<bool> DeleteAsync(int id);
    }
}
