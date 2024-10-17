using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoadDB_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_Razor.Pages.StdView
{
    public class IndexModel : PageModel
    {
        private readonly LoadDB_Razor.Models.PRN221_DBContext _context;

        public IndexModel(LoadDB_Razor.Models.PRN221_DBContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public bool IdFlag { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool NameFlag { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public bool GenderFlag { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public bool DobFlag { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public bool DepartFlag { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public bool GpaFlag { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? departmentId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? CurrentDepartmentId { get; set; }
        
        public List<Student> Student { get;set; } = default!;

        public void OnGetAsync(bool? idFlag, bool? nameFlag, bool? genderFlag, bool? dobFlag, bool? departFlag, string? currentDepartmentId)
        {
            // if(idFlag != null){
            //     IdFlag = idFlag.Value;
            // }
            // else if (nameFlag != null){
            //     NameFlag = nameFlag.Value;
            // }
            // else if (genderFlag != null){
            //     GenderFlag = genderFlag.Value;
            // }
            // if (_context.Students != null)
            // {
            //     Student =  _context.Students
            //         .ToList();
            // }
            Student ??= _context.Students.Include(s => s.Depart).ToList();
        }
        
        // public List<Student> GetStudents(){
        //     return _context.Students.Include(s => s.Depart)
        //         .Where(s => string.IsNullOrEmpty(DepartmentId) || s.Depart != null && s.Depart.Id == DepartmentId)
        //         .ToList();
        // }
        
        public IActionResult OnPost(){
            System.Console.WriteLine("DepartmentId:" + departmentId + " CurrentId: " + HttpContext.Session.GetString("currentDepartmentId"));
            
            if(string.IsNullOrEmpty(departmentId)){
                HttpContext.Session.Remove("currentDepartmentId");
            }
            
            if(!string.IsNullOrEmpty(Request.Form["searchButton"])){
                // departmentId = Request.Form["departmentId"];
                HttpContext.Session.SetString("currentDepartmentId", departmentId ?? "");
            }
            
            Student = _context.Students.Include(s => s.Depart)
                .Where(s => 
                    
                    s.Depart != null && (string.IsNullOrEmpty(HttpContext.Session.GetString("currentDepartmentId")) || s.Depart.Id == HttpContext.Session.GetString("currentDepartmentId"))
                    // string.IsNullOrEmpty(Request.Form["searchButton"]) ||
                    // string.IsNullOrEmpty(departmentId) || s.Depart != null && s.Depart.Id == departmentId
                )
                .ToList();
            
            if(!string.IsNullOrEmpty(Request.Form["btnIdSort"])){
                IdFlag = !IdFlag;
                Student = Student.OrderBy(s => IdFlag ? s.Id : -s.Id).ToList();
            }
            else if(!string.IsNullOrEmpty(Request.Form["btnNameSort"])){
                NameFlag = !NameFlag;
                Student = NameFlag ? Student.OrderBy(s => s.Name).ToList()
                    : Student.OrderByDescending(s => s.Name).ToList();  
            }
            else if(!string.IsNullOrEmpty(Request.Form["btnGenderSort"])){
                GenderFlag = !GenderFlag;
                Student = GenderFlag ? Student.OrderBy(s => s.Gender).ToList()
                    : Student.OrderByDescending(s => s.Gender).ToList();
            }
            else if(!string.IsNullOrEmpty(Request.Form["btnDobSort"])){
                DobFlag = !DobFlag;
                Student = DobFlag ? Student.OrderBy(s => s.Dob).ToList()
                    : Student.OrderByDescending(s => s.Dob).ToList();
            }
            else if(!string.IsNullOrEmpty(Request.Form["btnGpaSort"])){
                GpaFlag = !GpaFlag;
                Student = Student.OrderBy(s => GpaFlag ? s.Gpa : -s.Gpa).ToList();
            }
            else if(!string.IsNullOrEmpty(Request.Form["btnDepartSort"])){
                DepartFlag = !DepartFlag;
                Student = Student.Join(_context.Departments, s => s.DepartId, d => d.Id, (s, d) => new Student(){
                    Id = s.Id,
                    Name = s.Name,
                    Gender = s.Gender,
                    Dob = s.Dob,
                    DepartId = s.DepartId,
                    Gpa = s.Gpa,
                    Depart = d
                }).ToList();
                Student = DepartFlag ?  Student.OrderBy(s => s.Depart?.Name).ToList()
                    : Student.OrderByDescending(s => s.Depart?.Name).ToList();
                
            }
            else{
            }
            
            
            return Page();
        }
    }
}
