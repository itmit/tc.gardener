using gardener.Models;

namespace gardener.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		#region .ctor
		public ItemDetailViewModel(Item item = null)
		{
			Title = item?.Text;
			Item = item;
		}
		#endregion

		#region Properties
		public Item Item
		{
			get;
			set;
		}
		#endregion
	}
}
