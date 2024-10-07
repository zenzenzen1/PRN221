

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDB_Razor.Pages.SendData{
    public class LoginModel : PageModel{
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        
    }
}