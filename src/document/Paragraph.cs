using DFC.validator;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DFC.document;

public class Paragraph : DocumentElement
{
    private DocumentFormat.OpenXml.Wordprocessing.Paragraph _paragraph;
    
    public Paragraph(DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph)
    {
        _paragraph = paragraph;
    }

    public void Validate(DocumentElementValidator validator)
    {
        validator.Visit(this);
    }

    public ParagraphProperties Properties => _paragraph.ParagraphProperties;
}