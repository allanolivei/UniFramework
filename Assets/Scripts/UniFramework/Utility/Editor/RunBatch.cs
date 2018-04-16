namespace UniFramework.Utility
{
    using System.Diagnostics;

    public class RunBatch
    {

        public static void ExecuteCommand(string command, bool printOutput = false, string baseOutput = "")
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);
            string output = baseOutput;
            string errorOutput = "";

            if (printOutput)
            {
                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                            output += e.Data.ToString() + "\n";
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                    errorOutput += e.Data.ToString() + "\n";
                process.BeginErrorReadLine();
            }

            process.WaitForExit();

            if (printOutput)
            {
                UnityEngine.Debug.Log(output);
                if (errorOutput.Length > 1)
                    UnityEngine.Debug.Log("Errors: " + errorOutput);
                if (process.ExitCode != 0)
                    UnityEngine.Debug.Log("ExitCode: " + process.ExitCode);
            }

            process.Close();
        }
    }
}