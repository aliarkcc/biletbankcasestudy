using BiletBankCaseStudy.WebApp.ApiServices;
using BiletBankCaseStudy.WebApp.Core.Utilities.Responses;
using BiletBankCaseStudy.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIWithCoreMvc.Models;

namespace WebAPIWithCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAirportApiService _airportApiService;
        public HomeController(ILogger<HomeController> logger, IAirportApiService airportApiService)
        {
            _logger = logger;
            _airportApiService = airportApiService;
        }

        public async Task<IActionResult> Index()
        {
            ApiDataResponse<GenericListModel<Airport>> airportList = await _airportApiService.GetListAsync();
            if (airportList.Success)
                return View(airportList.Data);
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
