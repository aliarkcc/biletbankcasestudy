using BiletBankCaseStudy.WebApp.Core.Utilities.Responses;
using BiletBankCaseStudy.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace WebAPIWithCoreMvc.ApiServices
{
    public interface IHttpClientService
    {
        Task<ApiDataResponse<GenericListModel<T>>> GetListAsync<T>(string url);
        Task<ApiDataResponse<TResponseEntity>> PostAsync<TRequestEntity, TResponseEntity>(string url, TRequestEntity requestEntity, TResponseEntity responseEntity);

    }
    public class HttpClientService : IHttpClientService
    {
        IHttpContextAccessor _httpContextAccessor;
        HttpClient _httpClient;

        public HttpClientService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public async Task<ApiDataResponse<GenericListModel<T>>> GetListAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            var result = JsonConvert.DeserializeObject<ApiDataResponse<GenericListModel<T>>>(await response.Content.ReadAsStringAsync());

            return result;
        }
        public async Task<ApiDataResponse<TResponseEntity>> PostAsync<TRequestEntity, TResponseEntity>(string url, TRequestEntity requestEntity, TResponseEntity responseEntity)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(url, requestEntity);
            httpResponseMessage.EnsureSuccessStatusCode();
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiDataResponse<TResponseEntity>>(data);
            return await Task.FromResult(result);
        }
    }
}
