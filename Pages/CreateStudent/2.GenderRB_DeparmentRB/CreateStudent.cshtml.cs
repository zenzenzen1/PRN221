using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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
        
        public void OnPost(string gender, string departmentId){
            // Department department = JsonConvert.DeserializeObject<Department>(departmentId) ?? new Department();
            Student.Gender = gender == "male";
            Student.DepartId = departmentId;
            System.Console.WriteLine(Student);
            studentService.CreateStudent(Student);
        }
    }
}
