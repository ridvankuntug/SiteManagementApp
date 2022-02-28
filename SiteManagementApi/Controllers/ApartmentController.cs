using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Commands.DeleteApartment;
using SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment;
using SiteManagementInfrastructure.DatabaseContext;
using System;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    public class ApartmentController : ControllerBase
    {

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public ApartmentController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [HttpGet("GetAllApartment")]
        public IActionResult GetAllApartment()
        {
            try
            {
                GetAllApartmentQuery query = new GetAllApartmentQuery(_dataBase, _mapper);
                var apartmentObj = query.Handle();

                return Ok(apartmentObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetApartmentBy/{id}")]
        public IActionResult GetApartmentById(int id)
        {
            try
            {
                GetApartmentByIdQuery query = new GetApartmentByIdQuery(_dataBase, _mapper);
                query.newApartmentId = id;
                GetApartmentByIdValidator validator = new GetApartmentByIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetApartmentBy/{block}/{floor}/{no}")]
        public IActionResult GetApartmentByAdress(string block, int floor, int no)
        {
            try
            {
                GetApartmentByAdressQuery query = new GetApartmentByAdressQuery(_dataBase, _mapper);
                query.newApartmentBlock = block;
                query.newApartmentFloor = floor;
                query.newApartmentNo = no;
                GetApartmentByAdressValidator validator = new GetApartmentByAdressValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddApartment")]
        public IActionResult AddApartment([FromBody] AddApartmentModel newApartment)
        {
            try
            {
                AddApartmentCommand addApartment = new AddApartmentCommand(_dataBase, _mapper);
                AddApartmentValidator validationRules = new AddApartmentValidator();

                addApartment.Model = newApartment;
                validationRules.ValidateAndThrow(addApartment);
                addApartment.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("ChangeApartmentBy/{block}/{floor}/{no}")]
        //public IActionResult ChangeApartment(string block, int floor, int no, [FromBody] ChangeApartmentModel newApartment)
        //{
        //    try
        //    {
        //        ChangeApartmentCommand command = new ChangeApartmentCommand(_dataBase);
        //        command.newApartmentBlock = block;
        //        command.newApartmentFloor = floor;
        //        command.newApartmentNo = no;

        //        command.Model = newApartment;
        //        ChangeApartmentValidator validator = new ChangeApartmentValidator();
        //        validator.ValidateAndThrow(command);
        //        command.Handle();
        //        return Ok(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut("ChangeApartmentBy/{id}")]
        public IActionResult ChangeApartment(int id, [FromBody] ChangeApartmentModel newApartment)
        {
            try
            {
                ChangeApartmentCommand command = new ChangeApartmentCommand(_dataBase);
                command.newApartmentId = id;

                command.Model = newApartment;
                ChangeApartmentValidator validator = new ChangeApartmentValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteApartmentBy/{block}/{floor}/{no}")]
        public IActionResult DeleteApartment(string block, int floor, int no)
        {
            try
            {
                DeleteApartmentCommand command = new DeleteApartmentCommand(_dataBase);
                command.newApartmentBlock = block;
                command.newApartmentFloor = floor;
                command.newApartmentNo = no;

                DeleteApartmentValidator validator = new DeleteApartmentValidator();
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
