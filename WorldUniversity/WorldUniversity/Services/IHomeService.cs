using System.Collections.Generic;
using WorldUniversity.ViewModels;

namespace WorldUniversity.Services
{
    public interface IHomeService
    {
        IEnumerable<EnrollmentDateGroup> GetGeneralInformation();
    }
}
