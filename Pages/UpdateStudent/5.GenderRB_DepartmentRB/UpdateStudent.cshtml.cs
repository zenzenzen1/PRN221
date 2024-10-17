using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.MyView.UpdateStudent5
{
    public class UpdateStudentModel : PageModel
    {
        public Student Student { get; set; }
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
        
        public IActionResult OnPost(IFormCollection form)
        {
            var student = PRN221_DBContext.Instance.Students.Find(form["id"]);
            if(student != null){
                string gender = form["gender"];
                string departmentId = form["departmentId"];
                student.Gender = gender == "male";
                student.DepartId = departmentId;
                student.Name = form["name"];
                student.Gender = gender == "male";
                student.Dob = DateTime.Parse(form["dob"]);
                student.Gpa = double.Parse(form["gpa"]);
                PRN221_DBContext.Instance.Attach(student);
                PRN221_DBContext.Instance.SaveChanges();
                Student = student; 
            }
            else{
                return Page();
            }
            return RedirectToPage("../../MyView/Index/");
        }
    }
}
