using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt;
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



        [HttpPost("AddApartment")]
        public IActionResult AddDebt([FromBody] AddDebtModel newApartment)
        {
            try
            {
                AddDebtCommand addDebt = new AddDebtCommand(_dataBase, _mapper);
                AddDebtValidator validationRules = new AddDebtValidator();

                addDebt.Model = newApartment;
                validationRules.ValidateAndThrow(addDebt);
                addDebt.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
