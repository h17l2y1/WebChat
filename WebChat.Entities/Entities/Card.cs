using WebChat.Entities.Enums;

namespace WebChat.Entities.Entities
{
	public class Card : BaseEntity
	{
		public int Value { get; set; }
		public SuitsType Suit { get; set; }
		public RanksType Rank { get; set; }
	}
}