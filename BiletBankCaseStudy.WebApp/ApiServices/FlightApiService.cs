using BiletBankCaseStudy.WebApp.Core.Utilities.Responses;
using BiletBankCaseStudy.WebApp.Models;
using WebAPIWithCoreMvc.ApiServices;

namespace BiletBankCaseStudy.WebApp.ApiServices
{
    public interface IFlightApiService
    {
        Task<ApiDataResponse<FlightSearchListModel>> SearchFlightAsync(SearchForm searchForm);
    }
    public class FlightApiService : IFlightApiService
    {
        private readonly IHttpClientService _httpClientService;
        public FlightApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<FlightSearchListModel>> SearchFlightAsync(SearchForm searchForm)
        {
            return await _httpClientService.PostAsync("flight/search-flights", searchForm, new FlightSearchListModel());
        }
    }
}
