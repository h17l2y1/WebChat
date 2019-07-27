using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.ViewModels.User;

namespace WebChat.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
		private readonly IAccountService _service;

		public AccountController(IAccountService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> SignUp([FromBody] RequestSignUpAccount view)
		{
			await _service.SignUp(view);
			return Ok();
		}

	}
}