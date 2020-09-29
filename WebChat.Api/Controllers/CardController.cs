using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.ViewModels;

namespace WebChat.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CardController : Controller
	{
		private readonly ICardService _service;

		public CardController(ICardService service)
		{
			_service = service;
		}
		
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCardRequest request)
		{
			await _service.Create(request);
			return Ok();
		}
        
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			// await _service.GetAll();
			return Ok();
		}
	}
}