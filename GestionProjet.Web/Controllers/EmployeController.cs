using GestionProjet.Web.Models;
using GestionProjet.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionProjet.Web.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IEmployeService _employeService;
        public EmployeController(IEmployeService employeService)
        {
            _employeService = employeService;
        }

        public async Task<IActionResult> EmployeIndex()
        {
            List<EmployeDto> list = new();
            var response =await _employeService.GetAllEmployeAsync<ResponseDto>();
            list=JsonConvert.DeserializeObject<List<EmployeDto>>(Convert.ToString(response.Result));
            return View(list);
        }
        
        [HttpPost]
        public async Task<IActionResult> EmployeCreate(EmployeDto model)

        {
            var response=await _employeService.CreateEmployeAsync<EmployeDto>(model);
            if (response!=null && response.IsSuccess)
                return RedirectToAction(nameof(EmployeIndex));
            return View();
        }

    }
}
