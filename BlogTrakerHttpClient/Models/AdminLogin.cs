using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTrakerHttpClient.Models
{
    public class AdminLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]


        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}