using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface IStudentService
    {
        Task Create(CreateStudentInputViewModel input);
        StudentViewModel GetStudentDetails(int id);
        IQueryable<StudentViewModel> GetStudentAllData();
        Task UpdateStudent(string firstName,string lastName,DateTime enrollmentDate,int id);
        Task DeleteStudent(int id);
    }
}