using System;
using System.Collections.Generic;
using System.Linq;
using Cofoundry.Domain;
using AutoMapper;
using System.Threading.Tasks;
using Cofoundry.Core;
using Microsoft.AspNetCore.Html;

namespace Cofoundry.Web
{
    public class QuotationDisplayModelMapper : IPageBlockTypeDisplayModelMapper<QuotationDataModel>
    {
        public Task<IEnumerable<PageBlockTypeDisplayModelMapperOutput>> MapAsync(IEnumerable<PageBlockTypeDisplayModelMapperInput<QuotationDataModel>> inputs, WorkFlowStatusQuery workflowStatus)
        {
            return Task.FromResult(Map(inputs));
        }

        private IEnumerable<PageBlockTypeDisplayModelMapperOutput> Map(IEnumerable<PageBlockTypeDisplayModelMapperInput<QuotationDataModel>> inputs)
        {
            foreach (var input in inputs)
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