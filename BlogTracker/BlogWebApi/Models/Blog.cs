using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWebApi.Models
{
    public class Blog
    {
        
        public int BlogId { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [DataType(DataType.Text)]
        public string Subject { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfCreation { get; set; }
        [DataType(DataType.Url)]
        public string BlogUrl { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmpEmailId { get; set; }
    }
}