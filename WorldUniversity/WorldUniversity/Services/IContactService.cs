using System.Threading.Tasks;

namespace WorldUniversity.Services
{
    public interface IContactService
    {
        Task CreateAsync(string name, string email, string title, string content);
    }
}
