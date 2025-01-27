using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Interfaces.FiscalYear;

namespace Project.Application.Interfaces.FacadPatterns
{
    public interface IFiscalYearFacad
    {
        IAddFiscalYearService AddFiscalYearService { get; }

        IDeleteFiscalYearService DeleteFiscalYearService { get; }

        IUpdateFiscalYearService UpdateFiscalYearService { get; }

        IGetAllFiscalYearService GetAllFiscalYearService { get; }


    }
}
