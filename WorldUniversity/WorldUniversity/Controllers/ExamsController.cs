﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Controllers
{

    public class ExamsController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateQuestion()
        {
            return View();
        }
        public IActionResult CreateExam()
        {
            return View();
        }
    }  

}
