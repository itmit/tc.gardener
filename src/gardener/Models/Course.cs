using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace gardener.Models
{
	public class Course
	{
		public string Date
		{
			get;
			set;
		}

		public string PreviousDate
		{
			get;
			set;
		}

		public string PreviousUrl
		{
			get;
			set;
		}

		[JsonProperty("timestamp")]
		public int Timestamp
		{
			get;
			set;
		}

		[JsonProperty("rates")]
		public Rates Rates
		{
			get;
			set;
		}
	}
}
