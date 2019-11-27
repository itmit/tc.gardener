namespace gardener.Models
{
	public class BidForSale : BaseBid
	{
		#region .ctor
		public BidForSale(string placeNumber, string name, string phoneNumber, Block block, string row)
			: base(placeNumber, name, phoneNumber, block, row)
		{
		}

		public BidForSale(string placeNumber, string name, string phoneNumber, Block block, string row, int floor)
			: base(placeNumber, name, phoneNumber, block, row, floor)
		{
		}
		#endregion
	}
}
