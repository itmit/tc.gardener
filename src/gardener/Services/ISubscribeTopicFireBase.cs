using System.Threading.Tasks;

namespace gardener.Services
{
	public interface ISubscribeTopicFireBase
	{
		void Subscribe();

		void Unsubscribe();
	}
}
