using System.Diagnostics;
using System.Threading.Tasks;
using Photy.Services.Environment.Interfaces;

namespace Photy.Services.Environment.Implementations
{
    public class EnvironmentProcessService : IEnvironmentProcessService
    {
        public void Execute(string command, string arguments)
        {
            var process = GetProcess(command, arguments);

            process.Start();
        }

        public async Task<string> ExecuteAndGetOutput(string command, string arguments)
        {
            var process = GetProcess(command, arguments);

            process.Start();
            return await process.StandardOutput.ReadToEndAsync();
        }
        
        private static Process GetProcess(string command, string arguments, bool redirectOutput = false)
        {
            var processStartInfo = new ProcessStartInfo(command)
            {
                RedirectStandardOutput = redirectOutput,
                UseShellExecute = false,
                CreateNoWindow = false,
                Arguments = arguments
            };

            return new Process {StartInfo = processStartInfo};
        }
    }
}