using DFC.document;
using DFC.utils;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Logging;
using Paragraph = DFC.document.Paragraph;

namespace DFC.parser;

public class DocumentElementsParser
{
    public LinkedList<DocumentElement> Parse(FileInfo file)
    {
        Logger.Instance.LogInformation($"Parsing document {file.FullName}");

        LinkedList<DocumentElement> result = new LinkedList<DocumentElement>();

        using (WordprocessingDocument document = WordprocessingDocument.Open(file.FullName, false))
        {
            MainDocumentPart mainDocumentPart = document.MainDocumentPart!;
            Body body = mainDocumentPart.Document.Body!;

            foreach (var element in body.Elements())
            {
                if (element.GetType() == typeof(DocumentFormat.OpenXml.Wordprocessing.Paragraph))
                {
                    var paragraph = (DocumentFormat.OpenXml.Wordprocessing.Paragraph)element;

                    result.AddLast(new Paragraph(paragraph));
                }
                else if (element.GetType() == typeof(DocumentFormat.OpenXml.Wordprocessing.Paragraph))
                {
                    
                }
            }
        }

        // if (!new Docx2PdfConvertor(file.FullName).Convert())
        // {
        //     Logger.Instance.LogError($"Document {file.FullName} converting failed.");
        //     return result;
        // }
        
        Logger.Instance.LogInformation($"Document {file.FullName} has been parsed.");
        return result;
    }
}