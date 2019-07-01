namespace gardener.Models
{
	public enum MenuItemType
	{
		CurrencyQuotes,
		Rent,
		Selling,
		EmployCall,
		EmployCallLyon,
		CallSecurity,
		News,
		Map,
		Course
	}

	public class HomeMenuItem
	{
		#region Properties
		public MenuItemType Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}
		#endregion
	}
}
