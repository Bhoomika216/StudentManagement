using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class EditStudentModel : PageModel
    {
        StudentDataAccessLayer objstudent = new StudentDataAccessLayer();

        [BindProperty]
        public Student student { get; set; }
        public ActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            student = objstudent.GetStudentData(id);

            if (student == null)
            {
                return NotFound();
            }
            return Page();
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objstudent.UpdateStudent(student);

            return RedirectToPage("./StudentIndex");
        }
    }
}
