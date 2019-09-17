using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TSCS2.Models
{
    public class LoginModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}