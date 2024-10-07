using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.MyView.UpdateStudent2
{
    public class UpdateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; } = null!;
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
        
        public void OnPost(string departmentId)
        {
            Student.DepartId = departmentId;
            System.Console.WriteLine(Student);
            var student = PRN221_DBContext.Instance.Students.Find(Student.Id);
            if(student != null){
                student.Name = Student.Name;
                student.Gender = Student.Gender;
                student.DepartId = Student.DepartId;
                student.Dob = Student.Dob;
                student.Dob = Student.Dob;
                student.Gpa = Student.Gpa;
                PRN221_DBContext.Instance.Attach(student);
                PRN221_DBContext.Instance.SaveChanges();
                Student = student;
            }
            else{
                
            }
            // return RedirectToPage("../../Index/");
        }
    }
}
