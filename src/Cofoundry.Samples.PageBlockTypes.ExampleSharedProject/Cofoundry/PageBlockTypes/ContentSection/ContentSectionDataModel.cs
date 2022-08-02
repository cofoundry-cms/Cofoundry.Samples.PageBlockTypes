using Cofoundry.Domain;
using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes.ExampleSharedProject;

/// <summary>
/// This is a simple example block type to demonstrate how block types can be 
/// loaded in from other assemblies.
/// </summary>
public class ContentSectionDataModel : IPageBlockTypeDataModel, IPageBlockTypeDisplayModel
{
    [Display(Description = "Optional title to display at the top of the section")]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }
}