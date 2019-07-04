namespace gardener.Models
{
	public class Currency
	{
		public string Id
		{
			get;
			set;
		}

		public int NumCode
		{
			get;
			set;
		}

		public string CharCode
		{
			get;
			set;
		}

		public int Nominal
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public float Value
		{
			get;
			set;
		}

		public float Previous
		{
			get;
			set;
		}

		public string Image => CharCode + ".png";
	}
}
