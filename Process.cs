using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP32FirmwareUploader
{
    public static class ProcessExtensions
    {
        public static Task<bool> WaitForExitAsync(this Process process, int milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(true);
            if (!process.HasExited)
                return tcs.Task;
            return Task.FromResult(true);
        }

        public static Task<bool> WaitForExitAsync(this Process process)
        {
            return WaitForExitAsync(process, Timeout.Infinite);
        }
    }

}
