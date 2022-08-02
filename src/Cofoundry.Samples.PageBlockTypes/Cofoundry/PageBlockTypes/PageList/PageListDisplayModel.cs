namespace Cofoundry.Samples.PageBlockTypes;

public class PageListDisplayModel : IPageBlockTypeDisplayModel
{
    public ICollection<PageRoute> Pages { get; set; }
}