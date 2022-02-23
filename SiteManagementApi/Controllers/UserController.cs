using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteManagementInfrastructure.DatabaseContext;
using SiteManagementApplication.Operations.UserOperations.Queries.GetUser;
using System;
using FluentValidation;

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
    }
}