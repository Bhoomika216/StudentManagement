using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentManagement.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credentials { get; set; }
        public void OnGet()
        {
            this.Credentials = new Credential { AdminName = "admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            // Verify the Credential
            if(Credentials.AdminName == "admin" && Credentials.Password =="admin123")
            {
                // Creating the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                };
                var identity =new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");

            }
            return Page();
        }

        public class Credential
        {
            [Required]
            [Display(Name = "Admin Name")]
            public string AdminName { get; set; }

            [Required]
            [RegularExpression(@"^admin123$", ErrorMessage = "Password is incorrect")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
