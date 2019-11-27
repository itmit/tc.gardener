namespace gardener.Models
{
	public abstract class BaseBid
	{
		#region .ctor
		public BaseBid(string placeNumber, string name, string phoneNumber, Block block, string row)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
			Row = row;
		}

		public BaseBid(string placeNumber, string name, string phoneNumber, Block block, string row, int floor)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
			Row = row;
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
