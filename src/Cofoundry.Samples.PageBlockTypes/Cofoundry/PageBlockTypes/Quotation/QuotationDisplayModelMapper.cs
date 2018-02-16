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
        public Task<IEnumerable<PageBlockTypeDisplayModelMapperOutput>> MapAsync(
            IReadOnlyCollection<PageBlockTypeDisplayModelMapperInput<QuotationDataModel>> inputCollection, 
            PublishStatusQuery publishStatusQuery
            )
        {
            return Task.FromResult(Map(inputCollection));
        }

        private IEnumerable<PageBlockTypeDisplayModelMapperOutput> Map(IReadOnlyCollection<PageBlockTypeDisplayModelMapperInput<QuotationDataModel>> inputCollection)
        {
            foreach (var input in inputCollection)
            {
                var output = new QuotationDisplayModel();
                output.CitationText = input.DataModel.CitationText;
                output.CitationUrl = input.DataModel.CitationUrl;
                output.Quotation = new HtmlString(HtmlFormatter.ConvertLineBreaksToBrTags(input.DataModel.CitationText));
                output.Title = input.DataModel.Title;

                yield return input.CreateOutput(output);
            }
        }
    }
}