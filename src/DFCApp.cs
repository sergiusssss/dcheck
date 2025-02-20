using DFC.document;
using DFC.parser;
using DFC.utils;
using DFC.validator;
using Microsoft.Extensions.Logging;

namespace DFC;

using DocumentFormat.OpenXml.Packaging; 
using DocumentFormat.OpenXml.Wordprocessing;

public class DFCApp
{
    private Options _options;
    private List<FileInfo> _files;
    
    private DFC.document.Document _document;

    public DFCApp(Options options)
    {
        _options = options;
    }

    public bool LoadDocuments()
    {
        Logger.Instance.LogInformation($"Loading documents...");
        
        _files = new List<FileInfo>();

        if (_options.Directory != null)
        {
            foreach (FileInfo info in _options.Directory!.EnumerateFiles()!)
            {
                Logger.Instance.LogInformation($"Loading file {info.FullName}");
                _files.Add(info);
            }
        }
        else if (_options.File != null)
        {
            Logger.Instance.LogInformation($"Loading file {_options.File.FullName}");
            _files.Add(_options.File);
        }
        else
        {
            Logger.Instance.LogError("No valid files provided.");
            return false;
        }

        Logger.Instance.LogInformation($"Documents loaded.");
        return true;
    }

    public bool ParseDocuments()
    {
        Logger.Instance.LogInformation($"Parsing documents...");

        var parser = new DocumentElementsParser();
        
        LinkedList<DocumentElement> elements = new LinkedList<DocumentElement>();
        
        foreach (FileInfo info in _files)
        {
            foreach (DocumentElement newElement in parser.Parse(info))
            {
                elements.AddLast(newElement);
            }
        }

        _document = new DFC.document.Document(elements);
        
        Logger.Instance.LogInformation($"Documents parsed.");
        return true;
    }

    public Report CheckDocuments()
    {
        Logger.Instance.LogInformation($"Validating documents...");
        
        var report = new DocumentValidator().Validate(_document);
        
        Logger.Instance.LogInformation($"Documents validated.");

        return report;
    }
}