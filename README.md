# C Program Launcher (C#)

A simple C# program to launch a C program from within the same directory.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Example](#example)
- [Contributing](#contributing)
- [Contact](#contact)

## Introduction

The C Program Launcher in C# provides a straightforward way to run a C program from within a C# application. It allows the C# program to locate and execute a C program's executable residing in the same directory.

## Installation

To use the C Program Launcher, follow these steps:

1. Include the `Program.cs` file in your C# project.
2. Ensure that your project has the necessary dependencies for working with processes and file I/O.

## Usage

To use the C Program Launcher, follow these steps:

1. Set the `cProgramName` variable to the name of your C program's executable.
2. Place the C program's executable in the same directory as the C# program.
3. Run the C# program, and it will launch the specified C program.

## Example

```csharp
using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Directory where the C# program's executable is located
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
            process.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while starting the C program: {ex.Message}");
        }
    }
}
```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request in the repository.

## Contact

For any questions or further assistance, please feel free to contact:

- [Jorge Ricarte Passos Gonçalves](jorgericartepg@gmail.com)