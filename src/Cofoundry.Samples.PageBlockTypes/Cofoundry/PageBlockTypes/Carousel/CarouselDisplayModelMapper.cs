using Cofoundry.Core;
using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class CarouselDisplayModelMapper : IPageBlockTypeDisplayModelMapper<CarouselDataModel>
    {
        private readonly IImageAssetRepository _imageAssetRepository;

        public CarouselDisplayModelMapper(
            IImageAssetRepository imageAssetRepository
            )
        {
            _imageAssetRepository = imageAssetRepository;
        }

        public async Task MapAsync(
            PageBlockTypeDisplayModelMapperContext<CarouselDataModel> context,
            PageBlockTypeDisplayModelMapperResult<CarouselDataModel> result
            )
        {
            // Find all the image ids to load
            var allImageAssetIds = context
                .Items
                .SelectMany(m => m.DataModel.Slides)
                .Select(m => m.ImageId)
                .Where(i => i > 0)
                .Distinct();

            // Load image data
            var allImages = await _imageAssetRepository.GetImageAssetRenderDetailsByIdRangeAsync(allImageAssetIds, context.ExecutionContext);

            // Map display model
            foreach (var items in context.Items)
            {
                var output = new CarouselDisplayModel();

                output.Slides = EnumerableHelper
                    .Enumerate(items.DataModel.Slides)
                    .Select(m => new CarouselSlideDisplayModel()
                    {
                        Image = allImages.GetOrDefault(m.ImageId),
                        Text = m.Text,
                        Title = m.Title
                    })
                    .ToList();

                result.Add(items, output);
            }
        }
    }
}
