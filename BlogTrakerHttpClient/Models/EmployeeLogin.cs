using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTrakerHttpClient.Models
{
    public class EmployeeLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]


        public string Email { get; set; }
        [DataType(DataType.Password)]
        public int PassCode { get; set; }
    }
}