using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface IInstructorsService
    {
        Task Create(GetInstructorsDetailsViewModel input);

        GetInstructorsDetailsViewModel GetInstructorsDetails(int id);

        Task UpdateInstructor(string firstName, string lastName
            , DateTime hireDate, OfficeAssignment officeAssignment
            , int[] selectedCourseId, int id);

        InstructorIndexData GetInstructorAllData();

        Task DeleteInstructor(int id);

        ICollection<GetInstructorsDetailsViewModel> GetAllInstructors();
        bool InstructorExists(int id);
    }
}
