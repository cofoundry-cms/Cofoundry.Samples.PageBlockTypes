namespace Cofoundry.Samples.PageBlockTypes;

public class DirectoryListDisplayModel : IPageBlockTypeDisplayModel
{
    public IPagedQueryResult<PageRenderSummary> Pages { get; set; }
}