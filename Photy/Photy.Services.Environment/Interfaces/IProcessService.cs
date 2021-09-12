using System.Threading.Tasks;

namespace Photy.Services.Environment.Interfaces
{
    public interface IProcessService
    {
        /// <summary>
        ///     Execute a command with specified arguments.
        /// </summary>
        /// 
        /// <param name="command">
        ///     The command which should be executed.
        /// </param>
        /// 
        /// <param name="arguments">
        ///     The arguments for the command.
        /// </param>
        void Execute(string command, string arguments);

        /// <summary>
        ///     Executes a command async and returns the output of the corresponding process.
        /// </summary>
        /// 
        /// <param name="command">
        ///     The command which should be executed.
        /// </param>
        /// 
        /// <param name="arguments">
        ///     The arguments for the command.
        /// </param>
        /// 
        /// <returns>
        ///     The output of the command.
        /// </returns>
        Task<string> ExecuteAndGetOutput(string command, string arguments);
    }
}