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
            IEnumerable<PageBlockTypeDisplayModelMapperInput<DirectoryListDataModel>> inputs,
            PublishStatusQuery publishStatusQuery
            )
        {
            var results = new List<PageBlockTypeDisplayModelMapperOutput>();

            foreach (var input in inputs)
            {
                var output = new DirectoryListDisplayModel();

                // There's no batch search method so we need to do this for each input
                var query = new SearchPageSummariesQuery();
                query.PageDirectoryId = input.DataModel.PageDirectoryId;
                query.PageSize = input.DataModel.PageSize;

                // Pass through the workflow status so that we only show published pages 
                // when viewing the live site.
                // NB: The page search api is essentially borrowed from the admin panel
                // and could be improved upon for this type of querying. See issue #87
                if (publishStatusQuery == PublishStatusQuery.Published)
                {
                    query.PublishStatus = PublishStatus.Published;
                }

                output.Pages = await _pageRepository.SearchPageSummariesAsync(query);

                // The CreateOutput() method wraps the mapped display 
                // model with it's identifier so we can identify later on
                results.Add(input.CreateOutput(output));
            }

            return results;
        }
    }
}