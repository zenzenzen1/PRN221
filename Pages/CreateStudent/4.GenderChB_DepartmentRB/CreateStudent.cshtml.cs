using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent4
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
        
        public void OnPost(IFormCollection form){
            string gender = form["gender"];
            string departmentId = form["departmentId"];
            Student.Gender = gender == "male";
            Student.DepartId = departmentId;
            System.Console.WriteLine(Student);
            studentService.CreateStudent(Student);
            
        }
    }
}
