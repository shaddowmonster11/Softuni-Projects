using System;
using System.Collections.Generic;

namespace WorldUniversity.Data.Models.ExamModels
{
    public class Exam
    {
        public Exam()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Marks { get; set; }
        public bool IsArchived { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
