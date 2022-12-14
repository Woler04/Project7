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
    public class IndexModel : PageModel
    {
        private readonly Project7.Data.Project7Context _context;

        public IndexModel(Project7.Data.Project7Context context)
        {
            _context = context;
        }

        public IList<UserModel> UserModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserModel != null)
            {
                UserModel = await _context.UserModel.ToListAsync();
            }
        }
    }
}
