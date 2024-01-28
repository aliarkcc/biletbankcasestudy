using BiletBankCaseStudy.Application.Features.Airports.Models;
using BiletBankCaseStudy.Application.Features.Airports.Queries.GetList;
using BiletBankCaseStudy.Core.Application.Requests;
using BiletBankCaseStudy.Core.Utilities.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BiletBankCaseStudy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : BaseController
    {
        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(AirportListModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            pageRequest.PageSize = 80;
            GetListAirportsQuery getListAirportsQuery = new() { PageRequest = pageRequest };
            ApiDataResponse<AirportListModel> airportListModel = await Mediator.Send(getListAirportsQuery);
            if (airportListModel.Success)
                return Ok(airportListModel);

            return BadRequest();
        }
    }
}