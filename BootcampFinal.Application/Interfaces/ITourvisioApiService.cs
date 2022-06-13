using System;
using System.Collections.Generic;
using System.Text;
using BootcampFinal.Domain.HotelProducts;

namespace BootcampFinal.Application.Interfaces
{
    public interface ITourvisioApiService
    {
        string GetAccessToken();
        List<HotelProduct> GetHotels(string city, string token);
    }
}
