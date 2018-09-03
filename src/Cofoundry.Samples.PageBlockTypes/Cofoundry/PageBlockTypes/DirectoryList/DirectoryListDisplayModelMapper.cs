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

        public async Task<IEnumerable<PageBlockTypeDisplayModelMapperOutput>> MapAsync(
            IReadOnlyCollection<PageBlockTypeDisplayModelMapperInput<DirectoryListDataModel>> inputCollection,
            PublishStatusQuery publishStatusQuery
            )
        {
            var results = new List<PageBlockTypeDisplayModelMapperOutput>(inputCollection.Count);

            foreach (var input in inputCollection)
            {
                var output = new DirectoryListDisplayModel();

                var query = new SearchPageRenderSummariesQuery();
                query.PageDirectoryId = input.DataModel.PageDirectoryId;
                query.PageSize = input.DataModel.PageSize;

                // Pass through the workflow status so that we only show published pages 
                // when viewing the live site.
                query.PublishStatus = publishStatusQuery;

                output.Pages = await _pageRepository.SearchPageRenderSummariesAsync(query);

                // The CreateOutput() method wraps the mapped display 
                // model with it's identifier so we can identify later on
                results.Add(input.CreateOutput(output));
            }

            return results;
        }
    }
}