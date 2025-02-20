using DFC.document;

namespace DFC.validator;

public class DocumentValidator
{
    public Report Validate(Document document)
    {
        Report report = new Report();
        
        
        
        foreach (var element in document.Elements)
        {
            DocumentElementValidator validator = new DocumentElementValidator();
            element.Validate(validator);
        }
        
        return report;
    }
}