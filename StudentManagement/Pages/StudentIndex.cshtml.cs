using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Models;

namespace StudentManagement.Pages
{
    public class StudentIndexModel : PageModel
    {
        StudentDataAccessLayer objstudent = new StudentDataAccessLayer();
        public List<Student> student { get; set; }

        public void OnGet()
        {
            student = objstudent.GetAllStudents().ToList();
        }
    }
}
