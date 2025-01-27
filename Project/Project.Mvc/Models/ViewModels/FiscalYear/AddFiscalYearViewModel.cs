using System.ComponentModel.DataAnnotations;

namespace Project.Mvc.Models.ViewModels.FiscalYear
{
    public class AddFiscalYearViewModel
    {
        [Required(ErrorMessage="نام دوره را وارد کنید")]
        public string Name { get; set; }

        [Required(ErrorMessage = "تاریخ شروع را وارد کنید")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "تاریخ پایان را وارد کنید")]
        public DateTime EndDate { get; set; }
    }
}
