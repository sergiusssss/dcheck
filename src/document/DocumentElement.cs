using DFC.validator;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DFC.document;

public interface DocumentElement
{
    public void Validate(DocumentElementValidator validator);
}