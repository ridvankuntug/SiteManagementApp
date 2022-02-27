using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SiteManagementApplication.Operations.MessageOperations.Commands.AddMessage;
using SiteManagementApplication.Operations.MessageOperations.Commands.ChangeMessage;
using SiteManagementApplication.Operations.MessageOperations.Commands.DeleteMessage;
using SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage;
using SiteManagementInfrastructure.DatabaseContext;
using System;

namespace SiteManagementApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]s")]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _dataBase;
        private readonly IMapper _mapper;
        public MessageController(ApplicationDbContext dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }


        [HttpGet("GetAllMessage")]
        public IActionResult GetAllMessage()
        {
            try
            {
                GetAllMessageQuery query = new GetAllMessageQuery(_dataBase, _mapper);
                var messageObj = query.Handle();

                return Ok(messageObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMessageBy/{id}")]
        public IActionResult GetMessageById(int id)
        {
            try
            {
                GetMessageByIdQuery query = new GetMessageByIdQuery(_dataBase, _mapper);
                query.newMessageId = id;
                GetMessageByIdValidator validator = new GetMessageByIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMessageByReciver/{id}")]
        public IActionResult GetMessageByReciverId(int id)
        {
            try
            {
                GetMessageByReciverIdQuery query = new GetMessageByReciverIdQuery(_dataBase, _mapper);
                query.newReciverId = id;
                GetMessageByReciverIdValidator validator = new GetMessageByReciverIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMessageBySender/{senderId}/AndReciver/{reciverid}")]
        public IActionResult GetMessageBySenderIdAndReciverId(int senderId, int reciverid)
        {
            try
            {
                GetMessageBySenderIdAndReciverIdQuery query = new GetMessageBySenderIdAndReciverIdQuery(_dataBase, _mapper);
                query.newSenderId = senderId;
                query.newReciverId = reciverid;
                GetMessageBySenderIdAndReciverIdValidator validator = new GetMessageBySenderIdAndReciverIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMessageBySender/{id}")]
        public IActionResult GetMessageBySenderId(int id)
        {
            try
            {
                GetMessageBySenderIdQuery query = new GetMessageBySenderIdQuery(_dataBase, _mapper);
                query.newSenderId = id;
                GetMessageBySenderIdValidator validator = new GetMessageBySenderIdValidator();
                validator.ValidateAndThrow(query);

                var genreObj = query.Handle();

                return Ok(genreObj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddMessage")]
        public IActionResult AddMessage([FromBody] AddMessageModel newMessage)
        {
            try
            {
                AddMessageCommand addMessage = new AddMessageCommand(_dataBase, _mapper);
                AddMessageValidator validationRules = new AddMessageValidator();

                addMessage.Model = newMessage;
                validationRules.ValidateAndThrow(addMessage);
                addMessage.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeMessagenBy/{id}")]
        public IActionResult ChangeMessage(int id, [FromBody] ChangeMessageModel newMessage)
        {
            try
            {
                ChangeMessageCommand command = new ChangeMessageCommand(_dataBase);
                command.newMessageId = id;

                command.Model = newMessage;
                ChangeMessageValidator validator = new ChangeMessageValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReadMessage/{id}")]
        public IActionResult ReadMessage(int id)
        {
            try
            {
                ReadMessageCommand command = new ReadMessageCommand(_dataBase);
                command.newMessageId = id;

                ReadMessageValidator validator = new ReadMessageValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteMessageBy/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            try
            {
                DeleteMessageCommand command = new DeleteMessageCommand(_dataBase);
                command.newMessageId = id;

                DeleteMessageValidator validator = new DeleteMessageValidator();
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
