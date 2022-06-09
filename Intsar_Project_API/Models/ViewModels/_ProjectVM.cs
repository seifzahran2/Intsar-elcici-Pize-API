using System.ComponentModel.DataAnnotations;

namespace Intsar_Project_API.Models.ViewModels
{
    public class _ProjectVM
    {
        [Required(ErrorMessage = "برجاء ادخال رابط درايف الخاص بك")]
        public string DriveLink { get; set; }
    }
}
