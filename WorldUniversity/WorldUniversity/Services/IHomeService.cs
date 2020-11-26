using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models.ViewModels;

namespace WorldUniversity.Services
{
    public interface IHomeService
    {
        IEnumerable<EnrollmentDateGroup> GetGeneralInformation();
    }
}
