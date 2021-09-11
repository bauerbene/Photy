using System.Threading.Tasks;

namespace Photy.Services.Environment.Interfaces
{
    public interface IProcessService
    {
        void Execute(string command, string arguments);

        Task<string> ExecuteAndGetOutput(string command, string arguments);
    }
}