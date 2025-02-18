namespace DFC;

using CommandLine;

public class Options
{
    [Option('f', "file", Required = false, HelpText = "Path to a file to be processed.")]
    public FileInfo? File { get; set; }
        
    [Option('d', "directory", Required = false, HelpText = "Path to a directory to be processed.")]
    public DirectoryInfo? Directory { get; set; }
        
    [Option('v', "verbose", Default = false, Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}