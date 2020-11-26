using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartmentViewModel> GetAdmin();
        bool DepartmentExists(int id);
        DepartmentViewModel GetDepartmentDetails(int id);
        Task Create(DepartmentViewModel input);
        Task DeleteDepartment(int id);
        Task UpdateDepartment(int departmentId,string name
            , decimal budget,DateTime startDate,int instructorId);
    }
}
