using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.ViewModels;

namespace WorldUniversity.Services
{
    public interface IHomeService
    {
        IEnumerable<EnrollmentDateGroup> GetGeneralInformation();
    }
}
