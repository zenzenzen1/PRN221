using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.MyView.UpdateStudent6
{
    public class UpdateStudentModel : PageModel
    {
        public Student Student { get; set; } = new();
        public IActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return RedirectToPage("/MyView/Index");
            }
            var student = PRN221_DBContext.Instance.Students.Find(id);
            if(student == null)
            {
                return RedirectToPage("/MyView/Index");
            }
            Student = student;
            return Page();
        }
        
        public IActionResult OnPost(string gender, string departmentId, string id, string name, string dob, string gpa)
        {
            if (gender == null || departmentId == null || id == null || name == null || gpa == null)
            {
                return Page();
            }
            Student.DepartId = departmentId;
            var student = PRN221_DBContext.Instance.Students.Find(int.Parse(id));
            if(student != null){
                Student.Name = name;
                if (dob != null)
                {
                    Student.Dob = DateTime.Parse(dob);
                }
                Student.Gender = gender == "male";
                Student.DepartId = departmentId;
                Student.Gpa = double.Parse(gpa);
                PRN221_DBContext.Instance.Attach(student);
                PRN221_DBContext.Instance.SaveChanges();
                Student = student;
            }
            else{
                
            }
            return RedirectToPage("../../MyView/Index/");
        }
    }
}
