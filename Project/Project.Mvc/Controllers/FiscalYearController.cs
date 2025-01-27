using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Application.Interfaces.FacadPatterns;
using Project.Application.Services.FiscalYear.Commands.Add;
using Project.Application.Services.FiscalYear.Commands.Update;
using Project.Application.Services.FiscalYear.Queries.GetAll;
using Project.Mvc.Models.ViewModels.Common;
using Project.Mvc.Models.ViewModels.FiscalYear;

namespace Project.Mvc.Controllers
{
    public class FiscalYearController : Controller
    {
        private readonly IFiscalYearFacad _fiscalYearFacad;

        public FiscalYearController(IFiscalYearFacad fiscalYearFacad)
        {
            _fiscalYearFacad = fiscalYearFacad;
        }

        public async Task<IActionResult> Index([FromQuery] QueryStringViewModel request)
        {
            var fiscalYearList = await _fiscalYearFacad.GetAllFiscalYearService.Execute(new RequestGetAllFiscalYearDto
            {
                Page = request.Page,
                PageSize = request.PageSize,
                ordering = request.ordering
            });
         
            return View(fiscalYearList);
        }

        [HttpPost]
        [Route("/fiscalyear/Add")]
        public async Task<IActionResult> Add(AddFiscalYearViewModel request)
        {
         
            var addResult = await _fiscalYearFacad.AddFiscalYearService.Execute(new RequestAddFiscalYearDto
            {
             Name = request.Name,
             StartDate = request.StartDate,
             EndDate = request.EndDate,
            });

            return Json(addResult);
        }

        [HttpPost]
        [Route("/fiscalyear/Update")]
        public async Task<IActionResult> Update(UpdateFiscalYearViewModel request)
        {

            var updateResult = await _fiscalYearFacad.UpdateFiscalYearService.Execute(new RequestUpdateFiscalYearDto
            {   Id = request.Id,
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            });

            return Json(updateResult);
        }

        [HttpPost]
        [Route("/fiscalyear/Delete")]
        public async Task<IActionResult> Delete(string Id)
        {
            long id = JsonConvert.DeserializeObject<long>(Id);
            var deleteResult = await _fiscalYearFacad.DeleteFiscalYearService.Execute(id);

            return Json(deleteResult);
        }
    }
}
