namespace gardener.Models
{
	public class Bid
	{
		#region .ctor
		public Bid(string placeNumber, string name, string phoneNumber, Block block, string row, string text)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
			Row = row;
			Text = text;
		}

		public string Text
		{
			get;
			set;
		}

		public Bid(string placeNumber, string name, string phoneNumber, Block block, string row, int floor, string text)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
			Row = row;
			Text = text;
			Floor = floor;
		}
		#endregion

		#region Properties
		public Block Block
		{
			get;
			set;
		}

		public int Floor
		{
			get;
			set;
		}

		public string Row
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string PhoneNumber
		{
			get;
			set;
		}

		public string PlaceNumber
		{
			get;
			set;
		}
		#endregion
	}
}
