using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.ViewModels.Administration
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
