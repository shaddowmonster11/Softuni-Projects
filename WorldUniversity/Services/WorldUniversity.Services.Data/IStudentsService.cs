using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Web.ViewModels.Students;

namespace WorldUniversity.Services
{
    public interface IStudentsService
    {
        StudentViewModel GetStudentDetails(string id);
        IQueryable<StudentViewModel> GetStudentAllData();
        Task DeleteStudent(string id);
        bool IsEmailInUse(string email);
    }
}