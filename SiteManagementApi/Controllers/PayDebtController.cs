using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    public class PayDebtController : ControllerBase
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private readonly HttpClient _client;
        public PayDebtController(HttpClient client)
        {
            _client = client;
        }

        [HttpGet("PayDebt")]
        public async Task<string> PayDebt()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://localhost:6001/api/Payment/1234567890123456/2025/2/123/250");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                if(responseBody == "true")
                {
                    return "İşlem Başarılı";
                }
                else
                {
                    return "İşlem yapılamadı";
                }
            }
            catch (HttpRequestException e)
            {
                return "\nException Caught! \n Message :{0} " + e.Message;
            }
        }
    }
}