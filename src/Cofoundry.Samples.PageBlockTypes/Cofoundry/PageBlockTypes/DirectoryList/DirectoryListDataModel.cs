using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

public class DirectoryListDataModel : IPageBlockTypeDataModel
{
    [Display(Name = "Directory", Description = "A directory to list pages for.")]
    [PageDirectory]
    public int PageDirectoryId { get; set; }

    [Display(Name = "Page Size", Description = "The number of page links to show in the list.")]
    public int PageSize { get; set; }
}