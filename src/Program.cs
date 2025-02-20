﻿namespace DFC;

using CommandLine;

class Program
{
    static void Main(string[] args)
    {
        CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(HandleParseError);
    }
    static void RunOptions(Options opts)
    {
        //handle options
    }
    static void HandleParseError(IEnumerable<Error> errs)
    {
        //handle errors
    }
}