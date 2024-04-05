namespace Cofoundry.Samples.PageBlockTypes;

public class CarouselDisplayModel : IPageBlockTypeDisplayModel
{
    public IReadOnlyCollection<CarouselSlideDisplayModel> Slides { get; set; } = Array.Empty<CarouselSlideDisplayModel>();
}
