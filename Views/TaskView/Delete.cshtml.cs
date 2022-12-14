using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project7.Data;
using Project7.Models;

namespace Project7.Views.TaskView
{
    public class DeleteModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public DeleteModel(Project7.Data.Project7Context context)
        {
            _context = context;
        }

        [BindProperty]
      public TaskModel TaskModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TaskModel == null)
            {
                return NotFound();
            }

            var taskmodel = await _context.TaskModel.FirstOrDefaultAsync(m => m.TaskId == id);

            if (taskmodel == null)
            {
                return NotFound();
            }
            else 
            {
                TaskModel = taskmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TaskModel == null)
            {
                return NotFound();
            }
            var taskmodel = await _context.TaskModel.FindAsync(id);

            if (taskmodel != null)
            {
                TaskModel = taskmodel;
                _context.TaskModel.Remove(TaskModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
