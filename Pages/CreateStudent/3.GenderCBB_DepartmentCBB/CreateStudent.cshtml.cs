using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent3
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; } = null!;
        private readonly StudentService studentService;
        public CreateStudentModel(StudentService _studentService)
        {
            studentService = _studentService;
        }
        
        public void OnGet()
        {
        }
        
        public IActionResult OnPost(){
            string gender = Request.Form["gender"];
            string departmentId = Request.Form["departmentId"];
            Student.DepartId = departmentId;
            Student.Gender = gender == "male";
            studentService.CreateStudent(Student);
            
            return RedirectToPage("/MyView/Index");
        }
    }
}
