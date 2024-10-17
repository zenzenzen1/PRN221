using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LoadDb.Pages.CreateStudent1
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
        
        public IActionResult OnPost(string? gender, string departmentId)
        {
            // if(departmentId == null)
            // {
            //     return;
            // }
            
            if (Student != null)
            {
                Student.Gender = !string.IsNullOrEmpty(gender);
                Student.DepartId = departmentId;
                studentService.CreateStudent(Student);
            }
            return RedirectToPage("/MyView/Index");
        }
    }
}
