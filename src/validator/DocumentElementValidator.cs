using DFC.document;
using Header = DocumentFormat.OpenXml.Spreadsheet.Header;

namespace DFC.validator;

public class DocumentElementValidator
{
    public void Visit(Paragraph paragraph)
    {
        ParagraphValidator.Validate(paragraph);
    }
    
    
}