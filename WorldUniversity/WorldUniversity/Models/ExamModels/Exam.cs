﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.ExamModels
{
    public class Exam
    {
        public Exam()
        {
            this.Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Marks { get; set; }
        public string IsArchived { get; set; }
        public List<Question> Questions { get; set; }

    }
}