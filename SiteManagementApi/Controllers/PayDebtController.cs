using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt;
using SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using SiteManagementInfrastructure.DatabaseContext;
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

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;

        public PayDebtController(ApplicationDbContext dataBase, IMapper mapper, HttpClient client)
        {
            _client = client;
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [HttpGet("PayDebt")]
        public async Task<string> PayDebt(long cardNumber, int exYear, int exMonth, int ccv, long userTc, int debtMonth, int debtYear)
        {
            // Uzak sunucuya gittiğimiz için asenkron metod kullanıyoruz
            try
            {

                GetUserByTcQuery user = new GetUserByTcQuery(_dataBase, _mapper);
                user.newUserTc = userTc;
                GetUserByTcValidator getUserByTcValidator = new GetUserByTcValidator();
                getUserByTcValidator.ValidateAndThrow(user);
                var userObj = user.Handle();

                if (userObj is null)
                {
                    return "Kullanıcı bulunamadı";
                }

                GetDebtByUserIdWithPeriodQuery debt = new GetDebtByUserIdWithPeriodQuery(_dataBase, _mapper);
                debt.newUserId = userObj.Id;
                debt.newDebtMonth = debtMonth;
                debt.newDebtYear = debtYear;
                debt.newPaidCheck = true;
                GetDebtByUserIdWithPeriodValidator getDebtByUserIdValidator = new GetDebtByUserIdWithPeriodValidator();
                getDebtByUserIdValidator.ValidateAndThrow(debt);
                var debtObj = debt.Handle();

                if (debtObj is null)
                {
                    return "Ödenmemiş fatura bulunamadı";
                }

                string uri = "https://localhost:7001/api/Payment/"
                    + cardNumber + "/"
                    + exYear + "/"
                    + exMonth + "/"
                    + ccv + "/"
                    + debtObj.DebtTotal
                    + "?period=" + debtObj.DebtMonth + "-" + debtObj.DebtYear;

                string responseBody = await _client.GetStringAsync(uri);

                if (responseBody == "true")
                {
                    PayDebtCommand payDebt = new PayDebtCommand(_dataBase);
                    payDebt.newDebtId = debtObj.DebtId;
                    PayDebtValidator payDebtValidator = new PayDebtValidator();
                    payDebtValidator.ValidateAndThrow(payDebt);
                    payDebt.Handle();

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

        [HttpGet("PayDebtBy/{id}/{cardNumber}/{exYear}/{exMonth}/{ccv}")]
        public async Task<IActionResult> PayDebtById(int id, long cardNumber, int exYear, int exMonth, int ccv)
        {
            // Uzak sunucuya gittiğimiz için asenkron metod kullanıyoruz
            try
            {

                GetDebtByIdQuery debt = new GetDebtByIdQuery(_dataBase, _mapper);
                debt.newDebtId = id;
                GetDebtByIdValidator getDebtByUserIdValidator = new GetDebtByIdValidator();
                getDebtByUserIdValidator.ValidateAndThrow(debt);
                var debtObj = debt.Handle();

                if (debtObj is null)
                {
                    return BadRequest("Ödenmemiş fatura bulunamadı");
                }

                string uri = "https://localhost:7001/api/Payment/"
                    + cardNumber + "/"
                    + exYear + "/"
                    + exMonth + "/"
                    + ccv + "/"
                    + debtObj.DebtTotal
                    + "?period=" + debtObj.DebtMonth + "-" + debtObj.DebtYear;

                string responseBody = await _client.GetStringAsync(uri);

                if (responseBody == "true")
                {
                    PayDebtCommand payDebt = new PayDebtCommand(_dataBase);
                    payDebt.newDebtId = debtObj.DebtId;
                    PayDebtValidator payDebtValidator = new PayDebtValidator();
                    payDebtValidator.ValidateAndThrow(payDebt);
                    payDebt.Handle();

                    return Ok("İşlem Başarılı");
                }
                else
                {
                    return BadRequest("İşlem yapılamadı");
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest("\nException Caught! \n Message :{0} " + e.Message);
            }
        }
    }
}