﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Courses;
using WorldUniversity.Web.ViewModels.Instructors;

namespace WorldUniversity.Services
{
    public interface IInstructorsService
    {
        Task Create(GetInstructorsDetailsViewModel input);

        GetInstructorsDetailsViewModel GetInstructorsDetails(int? id);

        Task UpdateInstructor(string firstName, string lastName
            , DateTime hireDate, OfficeAssignment officeAssignment
            , int[] selectedId, int id);

        InstructorIndexData GetInstructorAllData();

        Task DeleteInstructor(int id);

        ICollection<GetInstructorsDetailsViewModel> GetAllInstructors();
        bool InstructorExists(string firstName, string lastName);
        List<AssignedCourseData> PopulateAssignedCourseData(GetInstructorsDetailsViewModel instructor
            , ICollection<CourseViewModel> allCourses);
    }
}
