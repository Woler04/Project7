using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project7.Data;
using Project7.Models;

namespace Project7.Views.TaskView
{
    public class EditModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public EditModel(Project7.Data.Project7Context context)
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

            var taskmodel =  await _context.TaskModel.FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskmodel == null)
            {
                return NotFound();
            }
            TaskModel = taskmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaskModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(TaskModel.TaskId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaskModelExists(int id)
        {
          return (_context.TaskModel?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
