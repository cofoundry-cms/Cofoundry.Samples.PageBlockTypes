namespace Cofoundry.Samples.PageBlockTypes;

public class DirectoryListDisplayModelMapper : IPageBlockTypeDisplayModelMapper<DirectoryListDataModel>
{
    private readonly IContentRepository _contentRepository;

    public DirectoryListDisplayModelMapper(
        IContentRepository contentRepository
        )
    {
        _contentRepository = contentRepository;
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
            displayModel.Pages = await _contentRepository
                .WithContext(context.ExecutionContext)
                .Pages()
                .Search()
                .AsRenderSummaries(query)
                .ExecuteAsync();

            result.Add(item, displayModel);
        }
    }
}