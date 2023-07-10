using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestExamPortal.Models;

namespace TestExamPortal.Controllers
{
    public class DropdownController : Controller
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public DropdownController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_configuration["APIURL"]);
        }
        public async Task<List<DropdownViewModel>> GetAllDiseases()
        {
            try
            {
                List<DropdownViewModel> list = new();
                HttpResponseMessage httpResponseMessage = await _client.GetAsync("Disease");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<DropdownViewModel>>(jsonResult);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
