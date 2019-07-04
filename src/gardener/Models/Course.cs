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

		public string Timestamp
		{
			get;
			set;
		}

		[JsonProperty("Valute")]
		public Valute Values
		{
			get;
			set;
		}
	}
}
