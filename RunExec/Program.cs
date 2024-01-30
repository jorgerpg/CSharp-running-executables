using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Get the directory where the C# program's executable is located
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Name of the C program executable
        string cProgramName = "hello";

        // Relative path to the C program's executable
        string cProgramPath = Path.Combine(currentDirectory, cProgramName);

        // Check if the C program file exists
        if (!File.Exists(cProgramPath))
        {
            Console.WriteLine($"The C program '{cProgramName}' was not found.");
            return;
        }

        // Create a process to run the C program
        Process process = new Process();

        // Configure the process
        process.StartInfo.FileName = cProgramPath;

        // Add the arguments passed to the C# program as arguments to the C program
        if (args.Length > 0)
        {
            process.StartInfo.Arguments = string.Join(" ", args);
        }

        // Start the process
        try
        {
            process.Start();
            
            // Wait for the C program to finish before continuing with the C# program
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while starting the C program: {ex.Message}");
        }
    }
}