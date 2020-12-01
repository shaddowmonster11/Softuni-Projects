﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.ViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Number")]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
