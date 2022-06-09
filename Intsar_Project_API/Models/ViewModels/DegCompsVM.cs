using System.ComponentModel.DataAnnotations;

namespace Intsar_Project_API.Models.ViewModels
{
    public class DegCompsVM
    {
        [Required(ErrorMessage ="يجب ادخال تقييم فكرة المشروع ")]
        public string ProjectIdea { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم جودة تنفيذ المشروع ")]
        public string ExecutionQuality { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم واجهة المستخدم ")]
        public string Gui { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم جودة المحتوى ")]
        public string ContentQuality { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم تعقيد المشروع ")]
        public string complexity { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم مقدار فائدة المشروع ")]
        public string ProjectBbenefit { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم اللغات المستخدمة ")]
        public string language_Tools { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم الادوات المستخدمه في المشروع ")]
        public string MasteringTheTools { get; set; }
        [Required(ErrorMessage = "يجب ادخال تقييم البنية الاساسيه للمشروع ")]
        public string InfrastructureUsed { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "يجب ادخال اختيار التقييم النهائي ")]
        public string OverallRating { get; set; }
    }
}
