﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateStudentInputViewModel input)
        {
            var student = new Student
            {
                Id=input.Id,
                FirstName=input.FirstName,
                LastName=input.LastName,
                EnrollmentDate=input.EnrollmentDate,
            };
           
           await _context.AddAsync(student);
           await _context.SaveChangesAsync();
        }

        public IQueryable<StudentViewModel> GetStudentAllData()
        {
            var student = _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .Select(x => new StudentViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EnrollmentDate = x.EnrollmentDate,
                Enrollments = x.Enrollments,
            }
            );

            return student;
        }

        public StudentViewModel GetStudentDetails(int id)
        {
            var student = _context.Students
               .Include(s => s.Enrollments)
               .ThenInclude(e => e.Course)
               .Select(x => new StudentViewModel
               {
                   Id = x.Id,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   EnrollmentDate = x.EnrollmentDate,
                   Enrollments = x.Enrollments,
               }
               )
               .FirstOrDefault();
            return student;
        }
    }
}
