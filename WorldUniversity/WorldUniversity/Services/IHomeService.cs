using System.Collections.Generic;
using WorldUniversity.ViewModels;
using WorldUniversity.ViewModels.Courses;

namespace WorldUniversity.Services
{
    public interface IHomeService
    {
        EnrollmentDateGroup GetGeneralInformation();
    }
}
