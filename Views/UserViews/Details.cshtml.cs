using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project7.Data;
using Project7.Models;

namespace Project7.Views.UserViews
{
    public class DetailsModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public DetailsModel(Project7.Data.Project7Context context)
        {
            _context = context;
        }

      public UserModel UserModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserModel == null)
            {
                return NotFound();
            }

            var usermodel = await _context.UserModel.FirstOrDefaultAsync(m => m.UserId == id);
            if (usermodel == null)
            {
                return NotFound();
            }
            else 
            {
                UserModel = usermodel;
            }
            return Page();
        }
    }
}
