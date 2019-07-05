namespace gardener.Models
{
	public class Currency
	{
		public Currency(string charCode, double value)
		{
			CharCode = charCode;
			Value = value;
		}

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

		public double Value
		{
			get;
			set;
		}

		public double Previous
		{
			get;
			set;
		}

		public string Image => CharCode + ".png";
	}
}
