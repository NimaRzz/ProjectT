using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.FiscalYear.Queries.GetAll
{
    public class ResultGetAllFiscalYearDto
    {
        public List<GetAllFiscalYearDto> Items { get; set; }

        public int TotalPages { get; set; }
    }
}
