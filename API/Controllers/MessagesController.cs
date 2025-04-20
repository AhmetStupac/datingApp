using API.DTOs;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageRepository messageRepository,
        IUserRepository userRepository, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var username = User.GetUsername();

            if(username == createMessageDto.RecipientUsername.ToLower())
                return BadRequest("You cannot message yourself");
            var sender = await userRepository.GetUserByUsernameAsync(username);
            // ovo je lik na kojem saljemo poruku/na kojeg smo kliknuli
            var recipient = await userRepository.GetUserByUsernameAsync(createMessageDto.RecipientUsername);
            if (recipient == null || sender == null) return BadRequest("Cannot send message atm");



        }
    }
}
    