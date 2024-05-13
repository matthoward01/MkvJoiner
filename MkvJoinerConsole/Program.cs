using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MKVCombinationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the folder containing .mkv files
            Console.WriteLine("Folder with Files to Combine?");
            string folderPath = Console.ReadLine().Replace("\"", "");

            // Get all .mkv files in the folder
            string[] mkvFiles = Directory.GetFiles(folderPath, "*.mkv");

            if (mkvFiles.Length == 0)
            {
                Console.WriteLine("No .mkv files found in the folder.");
                return;
            }

            // Generate command arguments to pass to mkvmerge
            string mkvmergeArgs = $"-o \"{Path.Combine(folderPath, "combined.mkv")}\" " +
                                   $"{string.Join(" + ", mkvFiles.Select(f => $"\"{f}\""))}";

            // Run mkvmerge to combine .mkv files
            ProcessStartInfo mkvmergeProcessInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\MKVToolNix\mkvmerge.exe",
                Arguments = mkvmergeArgs,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process mkvmergeProcess = new Process())
            {
                mkvmergeProcess.StartInfo = mkvmergeProcessInfo;
                mkvmergeProcess.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);
                mkvmergeProcess.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);

                mkvmergeProcess.Start();
                mkvmergeProcess.BeginOutputReadLine();
                mkvmergeProcess.BeginErrorReadLine();
                mkvmergeProcess.WaitForExit();
            }

            Console.WriteLine("Combination completed.");
            Main(args);
        }
    }
}
