using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Data;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(DepartmentViewModel input)
        {
            var department = new Department
            {
                DepartmentId = input.DepartmentId,
                Name = input.Name,
                Budget = input.Budget,
                StartDate = input.StartDate,
                InstructorId = input.InstructorId,
                RowVersion = input.RowVersion
            };
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDepartment(int id)
        {
            var deletedDepatment = _context.Departments
             .AsNoTracking()
             .FirstOrDefault(m => m.DepartmentId == id);

            if (await _context.Departments.AnyAsync(m => m.DepartmentId == deletedDepatment.DepartmentId))
            {
                _context.Departments.Remove(deletedDepatment);
                await _context.SaveChangesAsync();
            }
        }
        public bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
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
                     RowVersion = a.RowVersion,
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
                    RowVersion = x.RowVersion,
                    Administrator = x.Administrator,
                    Courses = x.Courses,
                })
                 .FirstOrDefault();
            return department;
        }

        public async Task UpdateDepartment(int departmentId, string name
            , decimal budget, DateTime startDate,int intructorId)
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
