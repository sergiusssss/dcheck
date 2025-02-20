using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace DFC.utils;

public class Docx2PdfConvertor
{
    private String _filePath;
    public Docx2PdfConvertor(String fileName)
    {
        _filePath = fileName;
    }

    public bool Convert()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Logger.Instance.LogInformation($"Converting {_filePath} to PDF (MacOSX)...");
            
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "/usr/bin/osascript",
                Arguments = "-l JavaScript convert.jxa " + _filePath + " " + _filePath.Replace("docx", "pdf"),
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            
            Logger.Instance.LogDebug($"-l JavaScript convert.jxa {_filePath} {_filePath.Replace("docx", "pdf")} false");
            
            Process proc = new Process()
            {
                StartInfo = startInfo,
            };
            
            proc.Start();
            
            while (!proc.StandardOutput.EndOfStream || !proc.StandardError.EndOfStream)
            {
                var standart_line = proc.StandardOutput.ReadLine()!;
                var error_line = proc.StandardError.ReadLine()!;
                if(standart_line != null) Logger.Instance.LogTrace($"\t {standart_line}");
                if(error_line != null) Logger.Instance.LogTrace($"\t {error_line}");
            }
            
            proc.WaitForExit();
            
            Logger.Instance.LogInformation($"File {_filePath} converted to pdf");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Logger.Instance.LogInformation($"Converting {_filePath} to PDF (Windows)...");
            
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            
            // TODO: Implement for windows
            
            Logger.Instance.LogInformation($"File {_filePath} converted to pdf");
        }
        
        return true;
    }
}