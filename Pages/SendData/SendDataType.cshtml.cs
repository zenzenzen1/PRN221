using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDB_Razor.Pages.SendData
{
    public class SendDataTypeModel : PageModel
    {
        [BindProperty]
        public int Int { get; set; }
        [BindProperty]
        public double Double { get; set; }
        [BindProperty]
        public bool Bool { get; set; }
        [BindProperty]
        public DateTime DateTime { get; set; }
        
        public void OnGet(){
        }
        
        public void OnPost(){
        }
    }
}
