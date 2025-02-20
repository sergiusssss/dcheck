namespace DFC;

using CommandLine;

public class Options
{
    [Option('f', "file", Required = false, HelpText = "Path to a file to be processed.")]
    public String File { get; set; }
        
    [Option('d', "directory", Required = false, HelpText = "Path to a directory to be processed.")]
    public String Directory { get; set; }
        
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}