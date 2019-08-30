using System;
using Newtonsoft.Json;
using Realms;

namespace gardener.Models
{
	public class News : RealmObject
	{
		#region Properties
		public string Uuid
		{
			get;
			set;
		} = Guid.NewGuid().ToString();

		[JsonProperty("created_at")]
		public DateTimeOffset CreatedAt
		{
			get;
			set;
		}

		[JsonProperty("picture")]
		public string ImageUrl
		{
			get;
			set;
		}

		[JsonProperty("body")]
		public string Text
		{
			get;
			set;
		}

		[JsonProperty("head")]
		public string Title
		{
			get;
			set;
		}
		#endregion
	}
}
