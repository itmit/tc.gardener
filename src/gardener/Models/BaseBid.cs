namespace gardener.Models
{
	public abstract class BaseBid
	{

		public BaseBid(string placeNumber, string name, string phoneNumber, Block block)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block.Title;
			Floor = 1;
		}
		public BaseBid(string placeNumber, string name, string phoneNumber, Block block, int floor)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block.Title;
			Floor = floor;
		}

		public string PlaceNumber
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

		public string Block
		{
			get;
			set;
		}

		public int Floor
		{
			get;
			set;
		}
	}
}
