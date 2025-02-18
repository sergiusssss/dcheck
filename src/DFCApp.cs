using DFC.utils;

namespace DFC;

using DocumentFormat.OpenXml.Packaging; 
using DocumentFormat.OpenXml.Wordprocessing;

public class DFCApp
{
    private List<String> _files = new List<String>();

    public DFCApp(Options options)
    {
        _files = new List<String>();

        if (options.Directory != null)
        {
            foreach (FileInfo info in options.Directory?.EnumerateFiles())
            {
                _files.Add(info.FullName);
            }
        }
    }

    public void LoadDocuments()
    {
        new Docx2PdfConvertor(_files.First()).Convert();
        // Load documents
        // Convert to PDF
    }

    public Report CheckDocuments()
    {
        return null;
    }
}