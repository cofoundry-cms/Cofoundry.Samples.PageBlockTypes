using Cofoundry.Core;
using Cofoundry.Core.Web;
using Cofoundry.Domain;
using Cofoundry.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cofoundry.Samples.PageModules
{
    /// <summary>
    /// A IPageModuleDisplayModelMapper class handles the mapping from
    /// a display model to a data model.
    /// 
    /// The mapper supports DI which gives you flexibility in what data
    /// you want to include in the display model and how you want to 
    /// map it. Mapping is done in batch to improve performance when 
    /// the same module type is used multiple times on a page
    /// </summary>
    public class DirectoryListDisplayModelMapper : IPageModuleDisplayModelMapper<DirectoryListDataModel>
    {
        private readonly IPageRepository _pageRepository;

        public DirectoryListDisplayModelMapper(
            IPageRepository pageRepository
            )
        {
            _pageRepository = pageRepository;
        }

        public IEnumerable<PageModuleDisplayModelMapperOutput> Map(
            IEnumerable<PageModuleDisplayModelMapperInput<DirectoryListDataModel>> inputs,
            WorkFlowStatusQuery workflowStatus
            )
        {
            foreach (var input in inputs)
            {
                var output = new DirectoryListDisplayModel();

                // There's no batch search method so we need to do this for each input
                var query = new SearchPageSummariesQuery();
                query.WebDirectoryId = input.DataModel.WebDirectoryId;
                query.PageSize = input.DataModel.PageSize;

                // Pass through the workflow status so that we only show published pages 
                // when viewing the live site.
                // NB: The page search api is essentially borrowed from the admin panel
                // and could be improved upon for this type of querying. See issue #87
                if (workflowStatus == WorkFlowStatusQuery.Published)
                {
                    query.WorkFlowStatus = WorkFlowStatus.Published;
                }

                output.Pages = _pageRepository.SearchPageSummaries(query);

                // The CreateOutput() method wraps the mapped display 
                // model with it's identifier so we can identify later on
                yield return input.CreateOutput(output);
            }
        }
    }
}