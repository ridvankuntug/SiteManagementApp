using Newtonsoft.Json;
using SiteManagementUi.Entities;
using SiteManagementUi.Models.ApartmentModels;
using System.Collections.Generic;

namespace SiteManagementUi.Services
{
    public class ApartmentService
    {
        static string jsonData = "";
        static public List<GetApartmentModel> GetAllApartments()
        {
            jsonData = WebApiService.GetAll("GetAllApartment").Result;
            return JsonConvert.DeserializeObject<List<GetApartmentModel>>(jsonData);
        }
        //static public Apartment GetApartment(int id)
        //{
        //    jsonData = WebApiService.GetSingle("getsingle", id).Result;
        //    return JsonConvert.DeserializeObject<Apartment>(jsonData);
        //}
        static public string PostApartment(AddApartmentModel apartment)
        {
            jsonData = WebApiService.Post<AddApartmentModel>("Apartments/AddApartment", apartment).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        static public string PutApartment(string block, int floor, int no, ChangeApartmentSenderModel apartment)
        {
            jsonData = WebApiService.Put<ChangeApartmentSenderModel>("Apartments/ChangeApartmentBy/"+block+"/"+floor+"/"+no , apartment).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        //static public string Delete(int id)
        //{
        //    jsonData = WebApiService.Delete("delete", id).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
    }
}
