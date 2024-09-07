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
    }
}
