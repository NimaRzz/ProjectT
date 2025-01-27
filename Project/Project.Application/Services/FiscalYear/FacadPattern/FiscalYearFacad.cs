using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.Interfaces.FacadPatterns;
using Project.Application.Interfaces.FiscalYear;
using Project.Application.Services.FiscalYear.Commands.Add;
using Project.Application.Services.FiscalYear.Commands.Delete;
using Project.Application.Services.FiscalYear.Commands.Update;
using Project.Application.Services.FiscalYear.Queries.GetAll;
using Project.Domain.Repository.FiscalYear;

namespace Project.Application.Services.FiscalYear.FacadPattern
{
    public class FiscalYearFacad : IFiscalYearFacad
    {
        private readonly IFiscalYearRepository _repository;
        public FiscalYearFacad(IFiscalYearRepository repository)
        {
            _repository = repository;
        }


        private IAddFiscalYearService _addFiscalYearService;

        public IAddFiscalYearService AddFiscalYearService
        {
            get
            {
                return _addFiscalYearService = _addFiscalYearService ?? new AddFiscalYearService(_repository);
            }
        }

        private IDeleteFiscalYearService _deleteFiscalYearService;

        public IDeleteFiscalYearService DeleteFiscalYearService
        {
            get
            {
                return _deleteFiscalYearService = _deleteFiscalYearService ?? new DeleteFiscalYearService(_repository);
            }
        }

        private IUpdateFiscalYearService _updateFiscalYearService;

        public IUpdateFiscalYearService UpdateFiscalYearService
        {
            get
            {
                return _updateFiscalYearService = _updateFiscalYearService ?? new UpdateFiscalYearService(_repository);
            }
        }

        private IGetAllFiscalYearService _getAllFiscalYearService;

        public IGetAllFiscalYearService GetAllFiscalYearService
        {
            get
            {
                return _getAllFiscalYearService = _getAllFiscalYearService ?? new GetAllFiscalYearService(_repository);
            }
        }
    }
}
