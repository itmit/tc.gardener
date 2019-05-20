namespace gardener.Models
{
	public class JsonDataResponse<T>
	{
		#region Properties
		public T Data
		{
			get;
			set;
		}

		public bool Success
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}
		#endregion
	}
}
