namespace gardener.Models
{
	public class BidForSale : BaseBid
	{
		public BidForSale(string placeNumber, string name, string phoneNumber, Block block)
			: base(placeNumber, name, phoneNumber, block)
		{
		}

		public BidForSale(string placeNumber, string name, string phoneNumber, Block block, int floor)
			: base(placeNumber, name, phoneNumber, block, floor)
		{
		}
	}
}
