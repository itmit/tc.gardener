using System.Threading.Tasks;

namespace gardener.Views.PortableInterface
{
	public interface ICallMaster
	{
		#region Overridable
		Task Call(string phoneNumber);
		#endregion
	}
}
