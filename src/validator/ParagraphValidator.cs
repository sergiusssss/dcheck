using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Logging;
using Paragraph = DFC.document.Paragraph;

namespace DFC.validator;

public class ParagraphValidator
{
    public static bool Validate(Paragraph paragraph)
    {
        if (paragraph.Properties is not null)
        {
            
        }
        if (paragraph.Properties?.TextAlignment != null && paragraph.Properties.TextAlignment.Val.Value != VerticalTextAlignmentValues.Auto)
        {
            Logger.Instance.LogError("incorrect alighment");
        }
        
        Logger.Instance.LogTrace("validating paragraph");
        return false;
    }
}