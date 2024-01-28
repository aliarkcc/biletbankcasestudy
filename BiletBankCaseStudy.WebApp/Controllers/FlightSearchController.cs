using BiletBankCaseStudy.WebApp.ApiServices;
using BiletBankCaseStudy.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiletBankCaseStudy.WebApp.Controllers
{
    public class FlightSearchController : Controller
    {
        private readonly IFlightApiService _flightApiService;

        public FlightSearchController(IFlightApiService flightApiService)
        {
            _flightApiService = flightApiService;
        }

        [Route("search-flights")]
        public async Task<ActionResult> SearchFlight(SearchForm searchForm)
        {
            var flightSearchResult = await _flightApiService.SearchFlightAsync(searchForm);
            return View(flightSearchResult.Data);

        }
    }
}
