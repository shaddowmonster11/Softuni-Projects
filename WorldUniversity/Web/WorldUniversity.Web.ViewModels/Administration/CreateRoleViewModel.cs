using System.ComponentModel.DataAnnotations;

namespace WorldUniversity.Web.ViewModels.Administration
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
