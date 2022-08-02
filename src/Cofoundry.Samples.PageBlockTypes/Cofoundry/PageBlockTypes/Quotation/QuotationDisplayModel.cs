using Microsoft.AspNetCore.Html;

namespace Cofoundry.Web;

public class QuotationDisplayModel : IPageBlockTypeDisplayModel
{
    public string Title { get; set; }
    public IHtmlContent Quotation { get; set; }
    public string CitationText { get; set; }
    public string CitationUrl { get; set; }
}