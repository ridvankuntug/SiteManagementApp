using Newtonsoft.Json;
using SiteManagementUi.Entities;
using SiteManagementUi.Models.UserModels;
using System.Collections.Generic;

namespace SiteManagementUi.Services
{
    public class UserService
    {
        static string jsonData = "";
        static public LoginToken SetToken
        {
            set
            {
                WebApiService.SetToken = value;
            }
        }
        static public LoginToken Token { get; set; }

        static public LoginToken GetLoginToken(string userName, string password)
        {
            string jsonToken = WebApiService.GetToken(userName, password).Result;
            LoginToken token = JsonConvert.DeserializeObject<LoginToken>(jsonToken);
            SetToken = token;
            Token = token;
            return token;
        }

        static public List<GetUserModel> GetAllUsers()
        {
            jsonData = WebApiService.GetAll("Users/GetAllUser").Result;
            return JsonConvert.DeserializeObject<List<GetUserModel>>(jsonData);
        }
        static public GetUserModel GetUser(int id)
        {
            jsonData = WebApiService.GetSingle("Users/GetUserBy", id).Result;
            return JsonConvert.DeserializeObject<GetUserModel>(jsonData);
        }
        //static public string PostUser(User user)
        //{
        //    jsonData = WebApiService.Post<User>("post", user).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}
        static public string PutUser(User user)
        {
            jsonData = WebApiService.Put<User>("put", user).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        //static public string Delete(int id)
        //{
        //    jsonData = WebApiService.Delete("delete", id).Result;
        //    return JsonConvert.DeserializeObject(jsonData).ToString();
        //}

    }
}
