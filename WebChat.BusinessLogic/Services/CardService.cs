using System.Threading.Tasks;
using WebChat.BusinessLogic.Services.Interfaces;
using WebChat.DataAccess.Repository.Interfaces;
using WebChat.Entities.Entities;
using WebChat.ViewModels;

namespace WebChat.BusinessLogic.Services
{
	public class CardService : ICardService
	{
		private readonly ICardRepository _cardRepository;

		public CardService(ICardRepository cardRepository)
		{
			_cardRepository = cardRepository;
		}
        
		public async Task Create(CreateCardRequest request)
		{
			Card card = new Card();
			card.Value = request.Value;
			// card.Rank = request.Rank;
			// card.Suit = request.Suit;
            
			await _cardRepository.Add(card);
		}
	}
}