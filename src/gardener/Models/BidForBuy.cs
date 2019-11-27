namespace gardener.Models
{
	public class BidForBuy : BaseBid
	{
		#region .ctor
		public BidForBuy(string placeNumber, string name, string phoneNumber, Block block, string row)
			: base(placeNumber, name, phoneNumber, block, row)
		{
		}

		public BidForBuy(string placeNumber, string name, string phoneNumber, Block block, string row, int floor)
			: base(placeNumber, name, phoneNumber, block, row, floor)
		{
		}
		#endregion
	}
}
