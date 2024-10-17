using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_Razor.Pages.StdView.Delete1
{
    public class DeleteModel : PageModel
    {
        private readonly LoadDB_Razor.Models.PRN221_DBContext _context;

        public DeleteModel(LoadDB_Razor.Models.PRN221_DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                student.Depart = await _context.Departments.FirstOrDefaultAsync(m => m.Id == student.DepartId);
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                Student = student;
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../../Index");
        }
    }
}
