using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PraksaWebApi.Models
{
    public class Student
    {
        public string name { get; set; }
        public string surname { get; set; }

        public bool IsValid()
        {
            return ((name != null) && (surname != null) && (name != "") && (surname != ""));
        }

    }
}