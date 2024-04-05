using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

public class CarouselDataModel : IPageBlockTypeDataModel
{
    [Required]
    [NestedDataModelCollection(IsOrderable = true, MinItems = 2, MaxItems = 6)]
    public IReadOnlyCollection<CarouselSlideDataModel> Slides { get; set; } = Array.Empty<CarouselSlideDataModel>();
}
