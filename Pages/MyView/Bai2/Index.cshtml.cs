using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_Razor.Pages.MyView.Bai2
{
    public class Index : PageModel
    {
        private readonly PRN221_DBContext _context;
        public List<Student> Students { get; set; } = new();
        public List<Department> Departments { get; set; } = new();
        public Index(PRN221_DBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Students = PRN221_DBContext.Instance.Students.Include(s => s.Depart).ToList();
            Departments = PRN221_DBContext.Instance.Departments.ToList();
        }
    }
}
