namespace Cofoundry.Samples.PageBlockTypes;

public class CarouselDisplayModel : IPageBlockTypeDisplayModel
{
    public ICollection<CarouselSlideDisplayModel> Slides { get; set; }
}
