using Newtonsoft.Json;
using SiteManagementUi.Entities;
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

        static public LoginToken GetLoginToken(string userName, string password)
        {
            string jsonToken = WebApiService.GetToken(userName, password).Result;
            LoginToken token = JsonConvert.DeserializeObject<LoginToken>(jsonToken);
            SetToken = token;
            return token;
        }

        static public List<User> GetAllUsers()
        {
            jsonData = WebApiService.GetAll("GetAllUser").Result;
            return JsonConvert.DeserializeObject<List<User>>(jsonData);
        }
        static public User GetUser(int id)
        {
            jsonData = WebApiService.GetSingle("getsingle", id).Result;
            return JsonConvert.DeserializeObject<User>(jsonData);
        }
        static public string PostPUser(User user)
        {
            jsonData = WebApiService.Post<User>("post", user).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        static public string PutUser(User user)
        {
            jsonData = WebApiService.Put<User>("put", user).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }
        static public string Delete(int id)
        {
            jsonData = WebApiService.Delete("delete", id).Result;
            return JsonConvert.DeserializeObject(jsonData).ToString();
        }

    }
}
