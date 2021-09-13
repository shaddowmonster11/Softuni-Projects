using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.ExamModels
{
    public class Question
    {
        public int Id{ get; set; }
        public int ExamId { get; set; }
        public string QuestionContent { get; set; }
        public string AlternateAnsOne { get; set; }
        public string AlternateAnsTwo { get; set; }
        public string AlternateAnsThree { get; set; }
        public string Answer { get; set; }
        public bool IsArchived { get; set; }

    }
}
