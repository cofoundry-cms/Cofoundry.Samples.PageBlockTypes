using Cofoundry.Core;
using Cofoundry.Core.Web;
using Cofoundry.Domain;
using Cofoundry.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class PageSnippetDisplayModelMapper : IPageBlockTypeDisplayModelMapper<PageSnippetDataModel>
    {
        private readonly IPageRepository _pageRepository;
        private readonly IHtmlSanitizer _htmlSanitizer;

        public PageSnippetDisplayModelMapper(
            IPageRepository pageRepository,
            IHtmlSanitizer htmlSanitizer
            )
        {
            _pageRepository = pageRepository;
            _htmlSanitizer = htmlSanitizer;
        }

        public async Task MapAsync(
            PageBlockTypeDisplayModelMapperContext<PageSnippetDataModel> context,
            PageBlockTypeDisplayModelMapperResult<PageSnippetDataModel> result
            )
        {
            var allPageIds = context.Items.SelectDistinctModelValuesWithoutEmpty(m => m.PageId);

            // The PageRenderDetails object contains page, template and block data targeting
            // a specific version. We pass through the PublishStatusQuery to ensure this is 
            // respected when querying related data i.e. if we're viewing a draft version then we
            // should also be able to see connected entities in draft status.
            var pagesQuery = new GetPageRenderDetailsByIdRangeQuery(allPageIds, context.PublishStatusQuery);
            var allPages = await _pageRepository.GetPageRenderDetailsByIdRangeAsync(pagesQuery, context.ExecutionContext);

            foreach (var item in context.Items)
            {
                var displayModel = new PageSnippetDisplayModel();

                displayModel.Page = allPages.GetOrDefault(item.DataModel.PageId);

                // We have to code defensively here and bear in mind that the related
                // entities may be in draft status and may not be available when viewing
                // the live site.
                if (displayModel.Page != null)
                {
                    // An example of querying the block data. Here we find all the raw html 
                    // page blocks and select all the data and strip out the html tags
                    var strippedHtml = displayModel
                        .Page
                        .Regions
                        .SelectMany(s => s.Blocks)
                        .Select(m => m.DisplayModel as RawHtmlDisplayModel)
                        .Where(m => m != null)
                        .Select(m => _htmlSanitizer.StripHtml(m.RawHtml));

                    // This is just an example of working with the data, in reality this
                    // would be much more dependent on your content.
                    var combinedText = string.Join(Environment.NewLine, strippedHtml);
                    displayModel.Snippet = TextFormatter.LimitWithElipsesOnWordBoundary(combinedText, 300);
                }

                // The CreateOutput() method wraps the mapped display 
                // model with it's identifier so we can identify later on
                result.Add(item, displayModel);
            }
        }
    }
}