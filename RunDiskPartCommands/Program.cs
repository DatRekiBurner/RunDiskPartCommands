using System.Diagnostics;

namespace RunDiskPartCommands
{
    class Program
    {
        internal static string s_workingDirectory
        {
            get
            {
                return Environment.SystemDirectory;
            }
        }

        internal static string s_file
        {
            get
            {
                return Path.Combine(s_workingDirectory, "diskpart.exe");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Process process = new Process()
                {
                    StartInfo = new()
                    {
                        WorkingDirectory = s_workingDirectory,
                        FileName = s_file,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = false,
                        UseShellExecute = false
                    }
                };
                process.Start();
#if DEBUG
                process.RunCommand("list disk");
#endif
                process.RunCommand("select disk 4");
                process.RunCommand("attributes disk clear readonly");
                process.RunCommand("exit");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
#if DEBUG
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.ReadLine();
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong!\nError: {ex.ToString()}\nPress enter to exit");
                Console.ReadLine();
            }
        }
    }
}