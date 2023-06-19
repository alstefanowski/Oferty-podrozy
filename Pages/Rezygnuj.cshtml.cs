using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Pages
{
    public class RezygnujModel : PageModel
    {
        private readonly DbContext _context;
        public RezygnujModel(DbContext context)
        {

        }
        public void OnGet()
        {

        }
    }
}
