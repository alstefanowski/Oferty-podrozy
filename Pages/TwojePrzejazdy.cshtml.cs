using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Data.Migrations;
using Projekt.Models;

namespace Projekt.Pages
{
    [Authorize]
    public class TwojePrzejazdyModel : PageModel
    {
        private readonly Projekt.Data.ApplicationDbContext _context;

        public TwojePrzejazdyModel(Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<UsersTrip> UsersTrip { get; set; } = default!;

        [BindProperty]
        public LoggedUserModel LoggedUser { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            string f_user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userstrip = await _context.UsersTrip.Where(a => a.UserId == f_user).ToListAsync();
            UsersTrip = userstrip;
            return Page();
        }
    }
}
