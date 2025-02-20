using System.Diagnostics;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Logging;

namespace DFC;

using System;
using CommandLine;

using DocumentFormat.OpenXml;

class Program
{
    private static DFCApp appInstance = null;
    
    static void Main(string[] args)
    {
        Logger.Initialize();
        
        CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(HandleParseError);
        
        if(appInstance == null) return;
        
        Logger.Instance.LogInformation("Starting DFC");

        if (appInstance.LoadDocuments() && appInstance.ParseDocuments())
        {
            Report report = appInstance.CheckDocuments();
        }
    }
    static void RunOptions(Options opts)
    {
        Logger.Instance.LogInformation("Selected directory: {}", (null == opts.Directory ? "<not set>" : opts.Directory));
        Logger.Instance.LogInformation("Selected file : {}", (null == opts.File ? "<not set>" : opts.File));
        Logger.Instance.LogInformation("Is verbose output : {}", opts.Verbose);

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
        
        Logger.Instance.LogError("Invalid options provided:");
        foreach (var error in errs)
        {
            Logger.Instance.LogError("\t" + error.ToString());     
        }
    }
}