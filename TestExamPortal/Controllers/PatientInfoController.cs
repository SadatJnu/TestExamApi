using deseaseId.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestExamApi.Controllers;
using TestExamApi.Data;
using TestExamApi.Entites;
using TestExamPortal.Models;

namespace TestExamPortal.Controllers
{
    public class PatientInfoController : Controller
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public PatientInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_configuration["APIURL"]);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientInfo([FromBody] PatientInfoViewModel model)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _client.PostAsJsonAsync("PatientInfo", model);
                if (httpResponseMessage.IsSuccessStatusCode)
                {                    
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientInfo([FromBody] PatientInfoViewModel model)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _client.PutAsJsonAsync($"PatientInfo/{model.ID}", model);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PatientInfoViewModels>> GetAllPatienInfo()
        {
            try
            {
                int count = 0;
                List<PatientInfoViewModels> list = new();
                List<DropdownViewModel> deseaseList = new();
                HttpResponseMessage httpResponseMessage = await _client.GetAsync("PatientInfo");
                HttpResponseMessage deseasResponse = await _client.GetAsync("Disease");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                    var deseasjsonResult = await deseasResponse.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<PatientInfoViewModels>>(jsonResult);
                    deseaseList = JsonConvert.DeserializeObject<List<DropdownViewModel>>(deseasjsonResult);
                    foreach (var item in list)
                    {
                        count++;
                        item.SL = count;
                        foreach (var deseas in deseaseList)
                        {
                            if (item.DeseaseId == deseas.Id)
                            {
                                item.DeseaseName = deseas.Name;
                            }
                            if ((int)item.EpilepsyId == 1)
                            {
                                item.EpilepsyName = "Yes";
                            }
                            else
                            {
                                item.EpilepsyName = "No";
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }

        public async Task<IActionResult> EditPatientInfoById(int id)
        {
            try
            {
                PatientInfoViewModel? patientInfo = new();
                HttpResponseMessage responseMessage = await _client.GetAsync($"PatientInfo/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonString = await responseMessage.Content.ReadAsStringAsync();
                    patientInfo = JsonConvert.DeserializeObject<PatientInfoViewModel>(jsonString);
                }
                return new JsonResult(patientInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _client.DeleteAsync($"PatientInfo/{id}");
                if (res.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

