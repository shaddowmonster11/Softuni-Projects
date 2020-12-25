using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels.Departments;

namespace WorldUniversity.Services
{
    public interface IDepartmentsService
    {
        IEnumerable<DepartmentViewModel> GetAdmin();
        bool DepartmentExists(int id);
        DepartmentViewModel GetDepartmentDetails(int id);
        Task Create(DepartmentInputModel input);
        Task DeleteDepartment(int id);
        Task UpdateDepartment(int departmentId,string name
            , decimal budget,DateTime startDate,int instructorId);
    }
}
