﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface ICoursesService
    {
        IEnumerable<AssignedCourseData> GetAll();
        Task Create(CourseViewModel input);
        IQueryable<Department> PopulateDepartment(object selectedDepartment = null);
        GetCoursesDetailsViewModel GetCoursesDetails(int id);
        Task DeleteCourse(int id);
        ICollection<CourseViewModel> GetAllCourses();
        Task UpdateCourse(int courseId,string title,int credits,int departmentId);
        bool CourseExists(int id);
    }
}
