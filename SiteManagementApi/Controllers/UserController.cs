﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementInfrastructure.DatabaseContext;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using System;
using FluentValidation;
using SiteManagementApplication.Operations.UserOperations.Commands.AddUser;
using SiteManagementApplication.Operations.UserOperations.Commands.ChangeUser;
using SiteManagementApplication.Operations.UserOperations.Commands.DeleteUser;
using SiteManagementApplication.Operations.UserOperations.Queries.LoginUser;
using Microsoft.AspNetCore.Authorization;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public UserController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("LoginUser/{userName}/{password}")]
        public IActionResult LoginUser(string userName, string password)
        {
            try
            {
                LoginUserQuery query = new LoginUserQuery(_dataBase, _mapper);
                query.newUserName = userName;
                query.newPassword = password;
                LoginUserValidator validator = new LoginUserValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUser")]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
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

        [HttpGet("GetUserBy/{id}")]
        [AllowAnonymous]
        public IActionResult GetUserBy(int id)
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

        [HttpGet("GetUserByTc/{tc}")]
        [AllowAnonymous]
        public IActionResult GetUserByTc(long tc)
        {
            try
            {
                GetUserByTcQuery query = new GetUserByTcQuery(_dataBase, _mapper);
                query.newUserTc = tc;
                GetUserByTcValidator validator = new GetUserByTcValidator();
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

        [Authorize(Roles = "user")]
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
        [AllowAnonymous]
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