using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent7
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; } = null!;
        public void OnGet()
        {
        }
        
        public void OnPost(string gender, string departmentId){
            Student.Gender = gender == "male";
            Student.DepartId = departmentId;
            System.Console.WriteLine(Student);
            new StudentService().CreateStudent(Student);
        }
    }
}
