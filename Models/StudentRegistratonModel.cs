using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class StudentRegistratonModel
    {
        [Required]
        [DisplayName("User Id")]
        public int id { get; set; }

        [Required]
        [DisplayName("User Email")]
        public  string email { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string password { get; set; }

        [Required]
        [DisplayName("Username")]
        public string name { get; set; }

    }
}