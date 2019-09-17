using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSCS2.Models
{
    public class RegistrationModelT
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string mobile_no { get; set; }
    }
}