﻿namespace gardener.Models
{
	public abstract class BaseBid
	{
		#region .ctor
		public BaseBid(string placeNumber, string name, string phoneNumber, Block block)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
		}

		public BaseBid(string placeNumber, string name, string phoneNumber, Block block, int floor)
		{
			PlaceNumber = placeNumber;
			Name = name;
			PhoneNumber = phoneNumber;
			Block = block;
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
