using BiletBankCaseStudy.WebApp.Core.Utilities.Responses;
using BiletBankCaseStudy.WebApp.Models;
using WebAPIWithCoreMvc.ApiServices;

namespace BiletBankCaseStudy.WebApp.ApiServices
{
    public interface IAirportApiService
    {
        Task<ApiDataResponse<GenericListModel<Airport>>> GetListAsync();
    }

    public class AirportApiService : IAirportApiService
    {
        private readonly IHttpClientService _httpClientService;
        public AirportApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<GenericListModel<Airport>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<Airport>("airport/getall");
        }
    }
}
