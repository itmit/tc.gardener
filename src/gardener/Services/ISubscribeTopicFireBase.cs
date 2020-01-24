using System.Threading.Tasks;

namespace gardener.Services
{
	public interface ISubscribeTopicFireBase
	{
		void SubscribeToAdminTopic();

		void UnsubscribeToAdminTopic();

		void SubscribeToAllTopic();
	}
}
