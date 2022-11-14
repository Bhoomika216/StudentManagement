using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Models
{
    public class Student
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        //Name
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter characters only")]
        public string Name { get; set; }


        //Age
        [Required(ErrorMessage = "Age is required"), MaxLength(3)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Please enter numbers only")]
        //[RegularExpression(@"^(\d){2}$", ErrorMessage = "Please enter two numbers only")]
        public string Age { get; set; }


        //DOB
        [Required(ErrorMessage = "Date of Birth is required")]
        [RegularExpression(@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$", ErrorMessage = "Enter correct format YYYY-MM-DD")]
        public string DOB { get; set; }


        //Phone Number
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(\d){10}$", ErrorMessage = "Please enter ten digits only")]
        public string Phone { get; set; }

        //Email
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        //Address
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }

    }
}