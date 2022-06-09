using System.ComponentModel.DataAnnotations;

namespace Intsar_F_Project.Models.ViewModels
{
    public class ContactVM
    {
        [Required(ErrorMessage = "تاكد من ادخال اسمك")]
        [MaxLength(20, ErrorMessage = "لا يزيد عدد حروف الاسم عن 20 حرف")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "تاكد من ادخال البريد الالكتروني")]
        [MaxLength(00, ErrorMessage = "لا يزيد عدد حروف البريد الالكتروني عن 20 حرف")]
        public string Email { get; set; }
        [Required(ErrorMessage = "تاكد من ادخال عنوان الموضوع")]
        [MaxLength(20, ErrorMessage = "لا يزيد عدد حروف عنوان الموضوع عن 20 حرف")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "تاكد من ادخال رسالتك")]
        [MaxLength(50, ErrorMessage = "لا يزيد عدد حروف الرسالة عن 50 حرف")]
        public string Message { get; set; }
    }
}
