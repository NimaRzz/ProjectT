using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Interfaces.FiscalYear;

namespace Project.Application.Services.FiscalYear.Queries.GetAll
{
    public class RequestGetAllFiscalYearDto
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public Ordering ordering { get; set; }
    }
}
