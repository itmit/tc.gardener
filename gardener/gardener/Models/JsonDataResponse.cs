namespace gardener.Models
{
	public class JsonDataResponse<T>
	{
		public bool Success
		{
			get;
			set;
		}

		public T Data
		{
			get;
			set;
		}
	}
}
