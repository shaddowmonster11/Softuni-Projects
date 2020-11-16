﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface IInstructorService
    {
        Task Create(GetInstructorsDetailsViewModel input);
        GetInstructorsDetailsViewModel GetInstructorsDetails(int id);
        Task UpdateInstructor(string firstName, string lastName
            , DateTime hireDate,OfficeAssignment officeAssignment
            , ICollection<CourseAssignment> courses, int id);
    }
}
