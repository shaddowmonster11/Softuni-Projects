﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Web.ViewModels.Departments;

namespace WorldUniversity.Services
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartmentViewModel> GetAdmin();
        bool DepartmentExists(string name);
        DepartmentViewModel GetDepartmentDetails(int id);
        Task Create(DepartmentInputModel input);
        Task DeleteDepartment(int id);
        Task UpdateDepartment(int departmentId, string name
            , decimal budget, DateTime startDate, int instructorId);
    }
}
