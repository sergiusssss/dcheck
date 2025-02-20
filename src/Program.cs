using System.Diagnostics;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DFC;

using System;
using CommandLine;

using DocumentFormat.OpenXml;

class Program
{
    private static DFCApp appInstance = null;
    
    static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(HandleParseError);

        OpenXmlMiscNode node = null;
    }
    static void RunOptions(Options opts)
    {
        Console.WriteLine("Selected directory: " + (null == opts.Directory ? "<not set>" : opts.Directory));
        Console.WriteLine("Selected file : " + (null == opts.File ? "<not set>" : opts.File));
        Console.WriteLine("Is verbose output : " + opts.Verbose);

        appInstance = new DFCApp(opts);
    }
    static void HandleParseError(IEnumerable<Error> errs)
    {
        bool isHelp = errs.Any(error => error.Tag is ErrorType.HelpRequestedError or
                                                     ErrorType.HelpVerbRequestedError);
        if (isHelp)
        {
            return;
        }
        
        Console.WriteLine("Invalid options provided:");
        foreach (var error in errs)
        {
            Console.WriteLine(error.ToString());     
        }
    }
}