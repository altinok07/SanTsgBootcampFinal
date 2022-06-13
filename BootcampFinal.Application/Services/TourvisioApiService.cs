using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BootcampFinal.Application.Interfaces;
using BootcampFinal.Domain.HotelDetails;
using BootcampFinal.Domain.HotelProducts;
using BootcampFinal.Domain.JWT;
using BootcampFinal.Shared.SettingsModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Hotel = BootcampFinal.Domain.HotelDetails.Hotel;

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
            Domain.JWT.Root myDeserializedClass = JsonConvert.DeserializeObject<Domain.JWT.Root>(stringJWT);

            return myDeserializedClass.body.token;
        }

        public List<HotelProduct> GetHotels(string query, string token)
        {
            List<HotelProduct> hotels = new List<HotelProduct>();
            string baseUrl = _settings.ServiceAddress;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            HotelProductRequest hotelProductRequest = new HotelProductRequest
            {
                ProductType = 2,
                Query = query,
                Culture = "en-US"
            };

            string stringData = JsonConvert.SerializeObject(hotelProductRequest);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/productservice/getarrivalautocomplete", contentData).Result;
            string hotelResult = response.Content.ReadAsStringAsync().Result;
            Domain.HotelProducts.Root myDeserializedClass = JsonConvert.DeserializeObject<Domain.HotelProducts.Root>(hotelResult);

            for (int i = 0; i < myDeserializedClass.body.items.Count; i++)
            {
                if (myDeserializedClass.body.items[i].hotel != null)
                {
                    HotelProduct hotelProduct = new HotelProduct();

                    hotelProduct.HotelId = myDeserializedClass.body.items[i].hotel.id;
                    hotelProduct.HotelName = myDeserializedClass.body.items[i].hotel.name;
                    hotelProduct.City = myDeserializedClass.body.items[i].city.name;
                    hotelProduct.Country = myDeserializedClass.body.items[i].country.name;

                    hotels.Add(hotelProduct);
                }
            }

            return hotels;

        }

        public Hotel GetHotelDetails(int id, string token)
        {
            string baseUrl = _settings.ServiceAddress;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            HotelDetailsRequest hotelDetailsRequest = new HotelDetailsRequest
            {
                ProductType = 2,
                OwnerProvider = 2,
                Product = id,
                Culture = "en-US"
            };

            string stringData = JsonConvert.SerializeObject(hotelDetailsRequest);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/api/productservice/getproductInfo", contentData).Result;
            string hotelDetailResult = response.Content.ReadAsStringAsync().Result;
            Domain.HotelDetails.Root myDeserializedClass = JsonConvert.DeserializeObject<Domain.HotelDetails.Root>(hotelDetailResult);


            return myDeserializedClass.body.hotel;
        }
    }
}
