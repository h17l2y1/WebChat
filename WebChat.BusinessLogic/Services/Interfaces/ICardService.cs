using System.Threading.Tasks;
using WebChat.ViewModels;

namespace WebChat.BusinessLogic.Services.Interfaces
{
	public interface ICardService
	{
		Task Create(CreateCardRequest request);
	}
}