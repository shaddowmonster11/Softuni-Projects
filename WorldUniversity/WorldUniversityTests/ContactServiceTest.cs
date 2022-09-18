using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldUniversity.Models;
using WorldUniversity.Repositories;
using WorldUniversity.Services;
using Xunit;

namespace WorldUniversityTests
{
    public class ContactServiceTest
    {
        [Fact]
        public async Task TestContactForm()
        {
            var contactUsList = new List<ContactForm>();
            var mockContactUsRepo = new Mock<IRepository<ContactForm>>();
            mockContactUsRepo.Setup(x => x.All()).Returns(contactUsList.AsQueryable());
            mockContactUsRepo.Setup(x => x.AddAsync(It.IsAny<ContactForm>())).Callback(
                (ContactForm contactUs) => contactUsList.Add(contactUs));

            var service = new ContactService(mockContactUsRepo.Object);

            await service.CreateAsync("Ivan Ivanov", "shaddowmonster11@gmail.com", "Test", "Test Content in contact form!");

            Assert.Single(contactUsList);
        }
    }
}
