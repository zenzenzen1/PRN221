using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_Razor.Pages.MyView.Bai1
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_DBContext _context;
        public List<Student> Students { get; set; } = new();
        public IndexModel(PRN221_DBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Students = PRN221_DBContext.Instance.Students.Include(s => s.Depart).ToList();
        }
    }
}
