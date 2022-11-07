﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogTrakerHttpClient.Models
{
    public class Emp1
    {
        [Required]
        [DataType(DataType.EmailAddress)]


        public string EmailId { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfJoining { get; set; }
        [DataType(DataType.Password)]
        public int PassCode { get; set; }
    }
}