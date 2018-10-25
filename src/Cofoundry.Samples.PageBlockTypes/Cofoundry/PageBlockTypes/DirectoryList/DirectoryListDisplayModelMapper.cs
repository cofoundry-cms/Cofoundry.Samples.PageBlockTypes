using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class DirectoryListDisplayModelMapper : IPageBlockTypeDisplayModelMapper<DirectoryListDataModel>
    {
        private readonly IPageRepository _pageRepository;

        public DirectoryListDisplayModelMapper(
            IPageRepository pageRepository
            )
        {
            _pageRepository = pageRepository;
        }
        
        public async Task MapAsync(
            PageBlockTypeDisplayModelMapperContext<DirectoryListDataModel> context, 
            PageBlockTypeDisplayModelMapperResult<DirectoryListDataModel> result
            )
        {
            foreach (var item in context.Items)
            {
                var query = new SearchPageRenderSummariesQuery();
                query.PageDirectoryId = item.DataModel.PageDirectoryId;
                query.PageSize = item.DataModel.PageSize;

                // Pass through the workflow status so that we only show published pages 
                // when viewing the live site.
                query.PublishStatus = context.PublishStatusQuery;

                var displayModel = new DirectoryListDisplayModel();
                displayModel.Pages = await _pageRepository.SearchPageRenderSummariesAsync(query, context.ExecutionContext);

                result.Add(item, displayModel);
            }
        }
    }
}