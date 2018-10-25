using Cofoundry.Core;
using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class PageListDisplayModelMapper : IPageBlockTypeDisplayModelMapper<PageListDataModel>
    {
        private readonly IPageRepository _pageRepository;

        public PageListDisplayModelMapper(
            IPageRepository pageRepository
            )
        {
            _pageRepository = pageRepository;
        }

        public async Task MapAsync(
            PageBlockTypeDisplayModelMapperContext<PageListDataModel> context, 
            PageBlockTypeDisplayModelMapperResult<PageListDataModel> result
            )
        {
            var allPageIds = context.Items.SelectManyDistinctModelValues(m => m.PageIds);

            // Page routes are cached and so are the quickest way to get simple page information.
            // If we needed more data we could use a different but slower query to get it.
            var allPageRoutes = await _pageRepository.GetPageRoutesByIdRangeAsync(allPageIds, context.ExecutionContext);

            foreach (var item in context.Items)
            {
                var displayModel = new PageListDisplayModel();

                // Here will get the relevant pages and order them correctly. 
                // Additionally if we are viewing the published version of the page
                // then we make sure we only show published pages in the list.

                displayModel.Pages = allPageRoutes
                    .FilterAndOrderByKeys(item.DataModel.PageIds)
                    .Where(p => context.PublishStatusQuery != PublishStatusQuery.Published || p.IsPublished())
                    .ToList();

                result.Add(item, displayModel);
            }
        }
    }
}