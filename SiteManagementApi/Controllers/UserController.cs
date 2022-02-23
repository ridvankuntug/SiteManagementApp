using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementInfrastructure.DatabaseContext;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using System;
using FluentValidation;
using SiteManagementApplication.Operations.UserOperations.Commands.AddUser;
using SiteManagementApplication.Operations.UserOperations.Commands.ChangeUser;
using SiteManagementApplication.Operations.UserOperations.Commands.DeleteUser;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public UserController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                GetAllUserQuery query = new GetAllUserQuery(_dataBase, _mapper);
                var userObj = query.Handle();

                return Ok(userObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                GetUserByIdQuery query = new GetUserByIdQuery(_dataBase, _mapper);
                query.newUserId = id;
                GetUserByIdValidator validator = new GetUserByIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            try
            {
                GetUserByNameQuery query = new GetUserByNameQuery(_dataBase, _mapper);
                query.newUserName = name;
                GetUserByNameValidator validator = new GetUserByNameValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] AddUserModel newUser)
        {
            try
            {
                AddUserCommand addUser = new AddUserCommand(_dataBase, _mapper);
                AddUserValidator validationRules = new AddUserValidator();

                addUser.Model = newUser;
                validationRules.ValidateAndThrow(addUser);
                addUser.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeUserBy/{id}")]
        public IActionResult ChangeUser(int id, [FromBody] ChangeUserModel newApartment)
        {
            try
            {
                ChangeUserCommand command = new ChangeUserCommand(_dataBase);
                command.newUserId = id;

                command.Model = newApartment;
                ChangeUserValidator validator = new ChangeUserValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUserBy/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                DeleteUserCommand command = new DeleteUserCommand(_dataBase);
                command.newUserId = id;

                DeleteUserValidator validator = new DeleteUserValidator();
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