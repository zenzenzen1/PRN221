using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoadDB_Razor.Pages.StdView.Create1
{
    public class CreateModel1 : PageModel
    {
        public readonly LoadDB_Razor.Models.PRN221_DBContext _context;

        public CreateModel1(LoadDB_Razor.Models.PRN221_DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Students == null || Student == null)
            {
               return Page();
            }
            
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("../../Index");
        }
    }
}
