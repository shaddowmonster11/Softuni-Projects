using System.Threading.Tasks;

namespace WorldUniversity.Services.Messaging
{
    public interface IMailHelper
    {
        Task SendContactFormAsync(string email, string names, string subject, string content);

        Task SendFromIdentityAsync(string email, string subject, string fullName, string url);
    }
}
