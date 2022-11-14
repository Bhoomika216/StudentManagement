using System;  
using System.Collections.Generic; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Models; 

namespace StudentManagement.Pages
{
    public class CreateStudentModel : PageModel
    {
        StudentDataAccessLayer objstudent = new StudentDataAccessLayer();  
  
        [BindProperty]  
        public Student student { get; set; }  
  
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
  
            objstudent.AddStudent(student);  
  
            return RedirectToPage("./StudentIndex");  
        } 
    }
}
