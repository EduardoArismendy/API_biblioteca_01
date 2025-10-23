using API_Biblioteca_01.Interfaces;
using API_Biblioteca_01.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Biblioteca_01.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // 📋 Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Books)
                .Include(u => u.Reviews)
                .ToListAsync();
        }

        // 🔍 Obtener usuario por ID
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Books)
                .Include(u => u.Reviews)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // ➕ Crear usuario
        public async Task<User> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // ✏️ Actualizar usuario
        public async Task<bool> UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.UpdatedAt = DateTime.Now;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return true;
        }

        // ❌ Eliminar usuario
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}