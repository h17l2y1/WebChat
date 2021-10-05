using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.ViewModels;

namespace WebChat.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IChatService _service;

        public ChatController(IChatService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody]MessageModel request)
        {
            await _service.Create(request);
            return Ok();
        }
    }
    
    
}