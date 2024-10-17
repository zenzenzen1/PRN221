using LoadDb.Services.StudentService;
using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent7
{
    public class CreateStudentModel : PageModel
    {
        public Student Student { get; set; } = new();
        public void OnGet()
        {
        }
        
        public IActionResult OnPost(string gender, string departmentId, string id, string name, string dob, string gpa){
            if (gender == null || departmentId == null || id == null || name == null || gpa == null) {
                return Page();
            }
            if(int.TryParse(id, out int Id))
            {
                Student? student = PRN221_DBContext.Instance.Students.Find(int.Parse(id));
                if (student == null)
                {
                    Student.Id = int.Parse(id);
                    Student.Name = name;
                    if (dob != null)
                    {
                        Student.Dob = DateTime.Parse(dob);
                    }
                    Student.Gender = gender == "male";
                    Student.DepartId = departmentId;
                    Student.Gpa = double.Parse(gpa);
                    

                    new StudentService().CreateStudent(Student);
                }
                return RedirectToPage("/MyView/Index");
            }
            else
            {
                return Page();
            }
            
           
        }
    }
}
