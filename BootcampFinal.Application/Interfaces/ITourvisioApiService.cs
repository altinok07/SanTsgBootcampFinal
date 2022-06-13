using System;
using System.Collections.Generic;
using System.Text;
using BootcampFinal.Domain.HotelDetails;
using BootcampFinal.Domain.HotelProducts;
using Hotel = BootcampFinal.Domain.HotelDetails.Hotel;

namespace BootcampFinal.Application.Interfaces
{
    public interface ITourvisioApiService
    {
        string GetAccessToken();
        List<HotelProduct> GetHotels(string city, string token);

        Hotel GetHotelDetails(int id, string token);
    }
}
    