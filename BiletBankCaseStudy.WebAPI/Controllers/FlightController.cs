using BiletBankCaseStudy.Application.Features.Flights.Models;
using BiletBankCaseStudy.Application.Features.Flights.Queries.GetList;
using BiletBankCaseStudy.Core.Application.Requests;
using BiletBankCaseStudy.Core.Utilities.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BiletBankCaseStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : BaseController
    {
        [HttpPost]
        [Route("search-flights")]
        public async Task<IActionResult> FlightSearch([FromQuery] PageRequest pageRequest, [FromBody] FlightSearchModel flightSearchModel)
        {
            GetListFlightsSearchQuery getListFlightsQuery = new() { PageRequest = pageRequest, SearchModel = flightSearchModel };

            ApiDataResponse<FlightSearchListModel> result = await Mediator.Send(getListFlightsQuery);
            return Ok(result);
        }
    }
}