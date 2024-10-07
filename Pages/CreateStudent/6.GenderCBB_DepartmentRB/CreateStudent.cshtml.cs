using LoadDB_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDb.Pages.CreateStudent6
{
    public class CreateStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; } = null!;
        public void OnGet()
        {
        }
        
        public void OnPost(string gender, string departmentId){
            
        }
    }
}
