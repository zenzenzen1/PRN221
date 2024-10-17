using System.Text.Json;
using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent2
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; } = null!;
        public readonly StudentService studentService;
        
        public CreateStudentModel(StudentService _studentService)
        {
            studentService = _studentService;
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnPost()
        {
            
            
            studentService.CreateStudent(Student);
            return RedirectToPage("/MyView/Index");
        }
    }
}
