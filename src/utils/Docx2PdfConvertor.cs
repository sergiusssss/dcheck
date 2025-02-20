using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DFC.utils;

public class Docx2PdfConvertor
{
    private String _filePath;
    public Docx2PdfConvertor(String fileName)
    {
        _filePath = fileName;
    }

    public void Convert()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "/usr/bin/osascript",
                Arguments = "-l JavaScript convert.jxa " + _filePath + " " + _filePath.Replace("docx", "pdf"),
                RedirectStandardOutput = true,
            };
            
            Console.WriteLine("-l JavaScript convert.jxa " + _filePath + " " + _filePath.Replace("docx", "pdf") + " false");
            
            Process proc = new Process()
            {
                StartInfo = startInfo,
            };
            
            proc.Start();
            
            while (!proc.StandardOutput.EndOfStream)
            {
                var result = proc.StandardOutput.ReadLine()!;
                Console.WriteLine(result);
            }
            proc.WaitForExit();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            
            // TODO: Implement for windows
        }
    }
}