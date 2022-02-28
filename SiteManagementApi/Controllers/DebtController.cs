using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt;
using SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt;
using SiteManagementApplication.Operations.DebtOperations.Commands.DelteDebt;
using SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt;
using SiteManagementInfrastructure.DatabaseContext;
using System;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    [Authorize]
    public class DebtController : ControllerBase
    {
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public DebtController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [HttpGet("GetAllDebt/{paidCheck}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllDebt(bool paidCheck)
        {
            try
            {
                GetAllDebtQuery query = new GetAllDebtQuery(_dataBase, _mapper);
                query.newPaidCheck = paidCheck;
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtBy/{id}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetDebtById(int id)
        {
            try
            {
                GetDebtByIdQuery query = new GetDebtByIdQuery(_dataBase, _mapper);
                GetDebtByIdValidator validationRules = new GetDebtByIdValidator();

                query.newDebtId = id;

                validationRules.ValidateAndThrow(query);
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtByUser/{id}/{paidCheck}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetDebtByUserId(int id, bool paidCheck)
        {
            try
            {
                GetDebtByUserIdQuery query = new GetDebtByUserIdQuery(_dataBase, _mapper);
                GetDebtByUserIdValidator validationRules = new GetDebtByUserIdValidator();

                query.newUserId = id;
                query.newPaidCheck = paidCheck;

                validationRules.ValidateAndThrow(query);
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtBy/{debtMonth}/{debtYear}/{paidCheck}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetDebtByPeriod(int debtMonth, int debtYear, bool paidCheck)
        {
            try
            {
                GetDebtByPeriodQuery query = new GetDebtByPeriodQuery(_dataBase, _mapper);
                GetDebtByPeriodValidator validationRules = new GetDebtByPeriodValidator();
                    
                query.newDebtMonth = debtMonth;
                query.newDebtYear = debtYear;

                query.newPaidCheck = paidCheck;

                validationRules.ValidateAndThrow(query);
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtByUser/{id}/With/{debthMonth}/{debtYear}/{paidCheck}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetDebtByUserIdWithPeriod(int id, int debtMonth, int debtYear, bool paidCheck)
        {
            try
            {
                GetDebtByUserIdWithPeriodQuery query = new GetDebtByUserIdWithPeriodQuery(_dataBase, _mapper);
                GetDebtByUserIdWithPeriodValidator validationRules = new GetDebtByUserIdWithPeriodValidator();

                query.newUserId = id;
                query.newDebtMonth = debtMonth;
                query.newDebtYear = debtYear;

                query.newPaidCheck = paidCheck;

                validationRules.ValidateAndThrow(query);
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AddDebt")]
        [Authorize(Roles = "admin")]
        public IActionResult AddDebt([FromBody] AddDebtModel newDebt)
        {
            try
            {
                AddDebtCommand addDebt = new AddDebtCommand(_dataBase, _mapper);
                AddDebtValidator validationRules = new AddDebtValidator();

                addDebt.Model = newDebt;
                validationRules.ValidateAndThrow(addDebt);
                addDebt.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddDebtToAll")]
        [Authorize(Roles = "admin")]
        public IActionResult AddDebtToAll([FromBody] AddDebtModel newDebt)
        {
            try
            {
                //Evsahiplerine aidatlarını paylaştırmak için daireleri çekiyoruz
                GetAllApartmentQuery query = new GetAllApartmentQuery(_dataBase, _mapper);
                //Boş olmayan dairelerin Id lerini alıyoruz
                var apartment = query.Handle().FindAll(c => c.User_Id is not null);

                AddDebtCommand addDebt = new AddDebtCommand(_dataBase, _mapper);
                AddDebtValidator validationRules = new AddDebtValidator();
                addDebt.Model = newDebt;
                //Toplam iadatı ve faturayı daire sayısına bölüyoruz
                float due = newDebt.DebtDue / apartment.Count;
                float bill = newDebt.DebtBill / apartment.Count;

                //dolu dairelerin sahiplerine borçlarını kaydediyoruz
                foreach (var item in apartment)
                {
                    addDebt.Model.DebtDue = due;
                    addDebt.Model.DebtBill = bill;
                    addDebt.Model.User_Id = (int)item.User_Id;
                    validationRules.ValidateAndThrow(addDebt);
                    addDebt.Handle();

                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("ChangeDebtBy/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult ChangeDebt(int id, [FromBody] ChangeDebtModel newDebt)
        {
            try
            {
                ChangeDebtCommand command = new ChangeDebtCommand(_dataBase);
                command.newDebtId = id;

                command.Model = newDebt;
                ChangeDebtValidator validator = new ChangeDebtValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PayDebtBy/{id}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult PayDebt(int id)
        {
            try
            {
                PayDebtCommand command = new PayDebtCommand(_dataBase);
                command.newDebtId = id;

                PayDebtValidator validator = new PayDebtValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteDebtBy/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteDebt(int id)
        {
            try
            {
                DeleteDebtCommand command = new DeleteDebtCommand(_dataBase);
                command.newDebtId = id;

                DeleteDebtValidator validator = new DeleteDebtValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
