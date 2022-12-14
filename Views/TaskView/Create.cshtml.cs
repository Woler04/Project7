using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project7.Data;
using Project7.Models;

namespace Project7.Views.TaskView
{
    public class CreateModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public CreateModel(Project7.Data.Project7Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TaskModel == null || TaskModel == null)
            {
                return Page();
            }

            _context.TaskModel.Add(TaskModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
