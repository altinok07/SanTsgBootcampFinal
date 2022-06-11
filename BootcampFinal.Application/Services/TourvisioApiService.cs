using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BootcampFinal.Application.Interfaces;
using BootcampFinal.Domain.JWT;
using BootcampFinal.Shared.SettingsModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BootcampFinal.Application.Services
{
    public class TourvisioApiService : ITourvisioApiService
    {

        private readonly TourvisioApiSettings _settings;

        public TourvisioApiService(IOptions<TourvisioApiSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GetAccessToken()
        {
            string baseUrl = _settings.ServiceAddress;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonConvert.SerializeObject(_settings);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/authenticationservice/login", contentData).Result;
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(stringJWT);

            return myDeserializedClass.body.token;
        }
    }
}
