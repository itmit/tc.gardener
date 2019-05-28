namespace gardener.Models
{
	public class BidForSale
	{
		public BidForSale(string placeNumber, string name, string phoneNumber)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
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
	}
}
