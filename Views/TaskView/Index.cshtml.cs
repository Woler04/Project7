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
    public class IndexModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public IndexModel(Project7.Data.Project7Context context)
        {
            _context = context;
        }

        public IList<TaskModel> TaskModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TaskModel != null)
            {
                TaskModel = await _context.TaskModel.ToListAsync();
            }
        }
    }
}
