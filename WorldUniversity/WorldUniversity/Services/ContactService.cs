using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Repositories;

namespace WorldUniversity.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactForm> repository;
        public ContactService(IRepository<ContactForm> repository)
        {
            this.repository = repository;
        }
        public async Task CreateAsync(string name, string email, string title, string content)
        {
            var contactForm = new ContactForm
            {
                Name = name,
                Email = email,
                Title = title,
                Content = content,
            };

            await this.repository.AddAsync(contactForm);
            await this.repository.SaveChangesAsync();
        }
    }
}
