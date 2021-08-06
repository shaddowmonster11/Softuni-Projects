using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.ExamModels;

namespace WorldUniversity.Models
{
    public class ExamAssignment
    {
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public Course Course { get; set; }
        public Exam Exam { get; set; }
    }
}
