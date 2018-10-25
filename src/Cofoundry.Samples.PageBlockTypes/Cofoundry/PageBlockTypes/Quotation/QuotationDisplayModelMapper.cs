using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain;
using System.Threading.Tasks;
using Cofoundry.Core;
using Microsoft.AspNetCore.Html;

namespace Cofoundry.Web
{
    public class QuotationDisplayModelMapper : IPageBlockTypeDisplayModelMapper<QuotationDataModel>
    {
        public Task MapAsync(
            PageBlockTypeDisplayModelMapperContext<QuotationDataModel> context,
            PageBlockTypeDisplayModelMapperResult<QuotationDataModel> result
            )
        {
            foreach (var item in context.Items)
            {
                var displayModel = new QuotationDisplayModel();
                displayModel.CitationText = item.DataModel.CitationText;
                displayModel.CitationUrl = item.DataModel.CitationUrl;
                displayModel.Quotation = new HtmlString(HtmlFormatter.ConvertLineBreaksToBrTags(item.DataModel.CitationText));
                displayModel.Title = item.DataModel.Title;

                result.Add(item, displayModel);
            }

            return Task.CompletedTask;
        }
    }
}