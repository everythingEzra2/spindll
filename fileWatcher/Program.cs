using System;
using System.IO;
using System.Security.Permissions;

public class fileWatcher
{
    public static void Main(string[] args)
    {
		if (args.Length != 3) 
		{
			throw new ArgumentException("3 arguments required: SourceDirectory, outputDirectory, fileName");
		}

		Console.WriteLine($"arg# {0} (source): {args[0]}");
		Console.WriteLine($"arg# {1} (destination): {args[1]}");
		Console.WriteLine($"arg# {2} (file??): {args[2]}");

        Run(args[0], args[1], args[2]);
    }

    // [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    private static void Run(string sourceDirectory, string outputDirectory, string fileName)
    {
        // Create a new FileSystemWatcher and set its properties.
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = sourceDirectory;

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = //NotifyFilters.LastAccess
                                NotifyFilters.LastWrite;
                                //  | NotifyFilters.FileName
                                //  | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = fileName;



            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
			Console.WriteLine($"watching file: {sourceDirectory}/{fileName}");

            // Wait for the user to quit the program.
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
    }

    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e) =>
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

    private static void OnRenamed(object source, RenamedEventArgs e) =>
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
}