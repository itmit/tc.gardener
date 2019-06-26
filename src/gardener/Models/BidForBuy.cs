namespace gardener.Models
{
	public class BidForBuy : BaseBid
	{
		public BidForBuy(string placeNumber, string name, string phoneNumber, Block block)
			: base(placeNumber, name, phoneNumber, block)
		{
		}

		public BidForBuy(string placeNumber, string name, string phoneNumber, Block block, int floor)
			: base(placeNumber, name, phoneNumber, block, floor)
		{
		}
	}
}
