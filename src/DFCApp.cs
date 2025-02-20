using DFC.utils;

namespace DFC;

using DocumentFormat.OpenXml.Packaging; 
using DocumentFormat.OpenXml.Wordprocessing;

public class DFCApp
{
    private List<String> _files = new List<String>();

    public DFCApp(Options options)
    {
        _files.Add(options.File);
    }

    public void LoadDocument()
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