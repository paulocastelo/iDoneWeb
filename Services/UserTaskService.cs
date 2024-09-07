using iDoneWeb.Data;
using iDoneWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace iDoneWeb.Services
{
    public class UserTaskService
    {
        private readonly ApplicationDbContext _context;
        public UserTaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserTask>> GetAllUserTasksAsync()
        {
            return await _context.UserTasks.ToListAsync();
        }
        // Create method
        public async Task<UserTask> CreateUserTaskAsync(UserTask userTask)
        {
            _context.Add(userTask);
            await _context.SaveChangesAsync();
            return userTask;
        }

        // Update method
        public async Task<UserTask> UpdateUserTaskAsync(UserTask userTask)
        {
            _context.Update(userTask);
            await _context.SaveChangesAsync();
            return userTask;
        }
        // Delete method
        public async Task<UserTask> DeleteUserTaskAsync(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                throw new ArgumentNullException(nameof(userTask), "User task not found.");
            }
            _context.UserTasks.Remove(userTask);
            await _context.SaveChangesAsync();
            return userTask;
        }

    }
}
