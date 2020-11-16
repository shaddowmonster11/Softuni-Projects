using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Services
{
    public interface IInstructorService
    {
        Task Create(CreateStudentInputViewModel input);
    }
}
