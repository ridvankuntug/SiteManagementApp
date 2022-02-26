using Newtonsoft.Json;
using SiteManagementUi.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementUi.Services
{
    public class WebApiService
    {
        static string url = "https://localhost:6001/";
        static string serviceUrl = "";
        static HttpClient client = new HttpClient();
        static public LoginToken SetToken
        {
            set
            {
                if (value != null)
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + value.Token);
            }
        }
        public static async Task<string> GetToken(string userName, string password)
        {
            serviceUrl = $"{url}Api/Users/LoginUser/{userName}/{password}";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> GetAll(string method)
        {
            serviceUrl = $"{url}Api/Users/{method}";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GetSingle(string method, int id)
        {
            serviceUrl = $"{url}api/Users/{method}/{id}";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> Post<T>(string method, T instance) where T : class, new()
        {
            serviceUrl = $"{url}api/Users/{method}";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PostAsync(serviceUrl, httpContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static async Task<string> Put<T>(string method, T instance) where T : class, new()
        {
            serviceUrl = $"{url}api/Users/{method}";
            StringContent httpContent = new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await client.PutAsync(serviceUrl, httpContent))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static async Task<string> Delete(string method, int id)
        {
            serviceUrl = $"{url}api/Users/{method}/{id}";
            using (HttpResponseMessage response = await client.DeleteAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }

    }
}
