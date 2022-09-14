﻿using System;
using System.Collections.Generic;
using WorldUniversity.Models.Entities;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.Models
{
    public class ExamAssignment: IDeletableEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public Exam Exam { get; set; }
        public ICollection<ApplicationUser> Students { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
