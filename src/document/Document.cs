using DocumentFormat.OpenXml.Packaging;

namespace DFC.document;

public class Document
{
    private Dictionary<int, Page> _pages;
    private LinkedList<DocumentElement> _elements;

    public Document(LinkedList<DocumentElement> elements)
    {
        _elements = elements;
    }
    
    public LinkedList<DocumentElement> Elements => _elements;
}