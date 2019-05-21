namespace gardener.Models
{
	public enum MenuItemType
	{
		Rent,
		Selling,
		EmployCall,
		CallSecurity,
		Purchase
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
