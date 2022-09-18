using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
