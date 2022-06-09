using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intsar_Project_API.Models
{
    public class _project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Specialization { get; set; }
        [Required(ErrorMessage ="برجاء ادخال رابط درايف الخاص بك")]
        public string DriveLink { get; set; }
    }
}
