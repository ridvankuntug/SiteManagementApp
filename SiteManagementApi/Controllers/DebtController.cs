using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
    public class DebtController : ControllerBase
    {
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public DebtController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [HttpGet("GetAllDebt")]
        public IActionResult GetAllDebt()
        {
            try
            {
                GetAllDebtQuery query = new GetAllDebtQuery(_dataBase, _mapper);
                var debtObj = query.Handle();

                return Ok(debtObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDebtByUserId/{id}")]
        public IActionResult GetDebtByUserId(int id)
        {
            try
            {
                GetDebtByUserIdQuery query = new GetDebtByUserIdQuery(_dataBase, _mapper);
                GetDebtByUserIdValidator validationRules = new GetDebtByUserIdValidator();

                query.newUserId = id;
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
        public IActionResult AddDebt([FromBody] AddDebtModel newDebt)
        {
            try
            {
                AddDebtCommand addDebt = new AddDebtCommand(_dataBase, _mapper);
                AddDebtValidator validationRules = new AddDebtValidator();

                addDebt.Model = newDebt;
                validationRules.ValidateAndThrow(addDebt);
                addDebt.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("ChangeDebtBy/{id}")]
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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PayDebtBy/{id}")]
        public IActionResult PayDebt(int id)
        {
            try
            {
                PayDebtCommand command = new PayDebtCommand(_dataBase);
                command.newDebtId = id;

                PayDebtValidator validator = new PayDebtValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteDebtBy/{id}")]
        public IActionResult DeleteDebt(int id)
        {
            try
            {
                DeleteDebtCommand command = new DeleteDebtCommand(_dataBase);
                command.newDebtId = id;

                DeleteDebtValidator validator = new DeleteDebtValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
