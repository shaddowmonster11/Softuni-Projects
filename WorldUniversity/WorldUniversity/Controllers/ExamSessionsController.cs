using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Controllers
{
    public class ExamSessionsController:Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
