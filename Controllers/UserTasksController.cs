using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iDoneWeb.Data;
using iDoneWeb.Models;
using iDoneWeb.Services;

namespace iDoneWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTasksController : Controller
    {
        private readonly UserTaskService _userTaskService;

        public UserTasksController(UserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            var userTasks = await _userTaskService.GetAllUserTasksAsync();
            return View(userTasks);
        }

        // GET: UserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _userTaskService.GetAllUserTasksAsync();
            var task = userTask.FirstOrDefault(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: UserTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,DueDate,Status")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                await _userTaskService.CreateUserTaskAsync(userTask);
                return RedirectToAction(nameof(Index));
            }
            return View(userTask);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _userTaskService.GetAllUserTasksAsync();
            var task = userTask.FirstOrDefault(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: UserTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate,DueDate,Status")] UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userTaskService.UpdateUserTaskAsync(userTask);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserTaskExists(userTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userTask);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _userTaskService.GetAllUserTasksAsync();
            var task = userTask.FirstOrDefault(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userTaskService.DeleteUserTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserTaskExists(int id)
        {
            var userTasks = await _userTaskService.GetAllUserTasksAsync();
            return userTasks.Any(e => e.Id == id);
        }
    }
}
