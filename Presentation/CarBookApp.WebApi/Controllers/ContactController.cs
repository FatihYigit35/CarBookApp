using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(
        GetContactQueryHandler getContactQueryHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler,
        CreateContactCommandHandler createContactCommandHandler,
        UpdateContactCommandHandler updateContactCommandHandler,
        RemoveContactCommandHandler removeContactCommandHansler) : ControllerBase
    {
        private readonly GetContactQueryHandler _getContactQueryHandler = getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler = getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler = createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler = updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHansler = removeContactCommandHansler;

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var result = await _getContactQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHansler.Handle(new RemoveContactCommand(id));
            return Ok("Contact bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact bilgisi güncellendi.");
        }
    }
}
