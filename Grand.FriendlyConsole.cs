using System;
using System.Diagnostics;

namespace Grand.FriendlyConsole
{
    /// <summary>
    /// Call to create an instance.
    /// </summary>
    public class Friendly
    {
        /// <summary>
        /// Call to start your Console arguments.
        /// </summary>
        /// <param name="args">Arguments, like for example: cmd.exe</param>
        /// <param name="isTerminate">Terminate after job done?</param>
        /// <param name="outputVerboseMessage">Output your input details?</param>
        /// <param name="logCMDOutputResults">Log into file CMD output results?</param>
        /// <returns>Opens new cmd window with your arguments.</returns>
        public void Console(string args, bool isTerminate, bool outputVerboseMessage, bool logCMDOutputResults)
        {
            string Date = $"{DateTime.Now.Hour.ToString("d2")}-{DateTime.Now.Minute.ToString("d2")}-{DateTime.Now.Second.ToString("d2")}-{DateTime.Now.Millisecond.ToString("d2")}";
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "cmd.exe";
            if (logCMDOutputResults)
            {
                p.Arguments = (isTerminate == true) ? ($"/c {args} > log-{Date}.txt & type log-{Date}.txt") : ($"/k {args} > log-{Date}.txt & type log-{Date}.txt");
            }
            else if(logCMDOutputResults == false)
                p.Arguments = (isTerminate == true) ? ($"/c {args}") : ($"/k {args}");
            p.CreateNoWindow = false;
            Process.Start(p);
            if(outputVerboseMessage)
                System.Console.WriteLine($"Arguments: {args}\nIs terminated after job done? {isTerminate}\nIs logged output results: {logCMDOutputResults}");
        }
    }
}
