using Project.Application.Interfaces.FiscalYear;

namespace Project.Mvc.Models.ViewModels.Common
{
    public class QueryStringViewModel
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;

        public Ordering ordering { get; set; }
    }
}
