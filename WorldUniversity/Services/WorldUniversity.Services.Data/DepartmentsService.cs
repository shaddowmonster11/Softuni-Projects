﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Data.Models;
using WorldUniversity.Web.ViewModels.Departments;

namespace WorldUniversity.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(DepartmentInputModel input)
        {
            var department = new Department
            {
                DepartmentId = input.DepartmentId,
                Name = input.Name,
                Budget = input.Budget,
                StartDate = input.StartDate,
                InstructorId = input.InstructorId,
            };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDepartment(int id)
        {
            var deletedDepatment = _context.Departments
             .FirstOrDefault(m => m.DepartmentId == id);
            var courses = _context.Courses
                .Where(c => c.DepartmentId == deletedDepatment.DepartmentId)
                .ToList();
            if (deletedDepatment != null)
            {
                deletedDepatment.IsDeleted = true;
                _context.Update(deletedDepatment);
                if (courses.Count != 0)
                {
                    foreach (var course in courses)
                    {
                        course.DepartmentId = null;
                        course.Department = null;
                        _context.Update(course);
                    }

                }

                await _context.SaveChangesAsync();
            }
        }
        public bool DepartmentExists(string name)
        {
            return _context.Departments.Any(e => e.Name == name);
        }

        public IEnumerable<DepartmentViewModel> GetAdmin()
        {
            var admin = _context.Departments
                 .Include(d => d.Administrator)
                 .Include(d => d.Courses)
                 .Select(a => new DepartmentViewModel
                 {
                     DepartmentId = a.DepartmentId,
                     InstructorId = a.InstructorId,
                     Name = a.Name,
                     Budget = a.Budget,
                     StartDate = a.StartDate,
                     Administrator = a.Administrator,
                     Courses = a.Courses,
                 })
                 .ToList();
            return admin;
        }
        public DepartmentViewModel GetDepartmentDetails(int id)
        {
            var department = _context.Departments
                .Where(x => x.DepartmentId == id)
                .Include(x => x.Courses)
                .Include(x => x.Administrator)
                .Select(x => new DepartmentViewModel
                {
                    DepartmentId = x.DepartmentId,
                    InstructorId = x.InstructorId,
                    Name = x.Name,
                    Budget = x.Budget,
                    StartDate = x.StartDate,
                    Administrator = x.Administrator,
                    Courses = x.Courses,
                })
                 .FirstOrDefault();
            return department;
        }

        public async Task UpdateDepartment(int departmentId, string name
            , decimal budget, DateTime startDate, int intructorId)
        {
            var updatedDepartment = _context.Departments
            .FirstOrDefault(s => s.DepartmentId == departmentId);
            updatedDepartment.DepartmentId = departmentId;
            updatedDepartment.Name = name;
            updatedDepartment.Budget = budget;
            updatedDepartment.StartDate = startDate;
            updatedDepartment.InstructorId = intructorId;
            await _context.SaveChangesAsync();
        }
    }
}
