using System.Threading.Tasks;

namespace gardener.Views.PortableInterface
{
    public interface ICallMaster
    {
        Task Call(string phoneNumber);
    }
}
