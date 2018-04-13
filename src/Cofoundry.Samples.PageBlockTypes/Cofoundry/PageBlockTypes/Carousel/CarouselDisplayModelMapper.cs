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

        public async Task<IEnumerable<PageBlockTypeDisplayModelMapperOutput>> MapAsync(
                IReadOnlyCollection<PageBlockTypeDisplayModelMapperInput<CarouselDataModel>> inputCollection, 
                PublishStatusQuery publishStatusQuery
            )
        {
            // Find all the image ids to load
            var allImageAssetIds = inputCollection
                .SelectMany(m => m.DataModel.Slides)
                .Select(m => m.ImageId)
                .Where(i => i > 0)
                .Distinct();

            // Load image data
            var allImages = await _imageAssetRepository.GetImageAssetRenderDetailsByIdRangeAsync(allImageAssetIds);
            var results = new List<PageBlockTypeDisplayModelMapperOutput>(inputCollection.Count);

            // Map display model
            foreach (var input in inputCollection)
            {
                var output = new CarouselDisplayModel();

                output.Slides = EnumerableHelper
                    .Enumerate(input.DataModel.Slides)
                    .Select(m => new CarouselSlideDisplayModel()
                    {
                        Image = allImages.GetOrDefault(m.ImageId),
                        Text = m.Text,
                        Title = m.Title
                    })
                    .ToList();

                results.Add(input.CreateOutput(output));
            }

            return results;
        }
    }
}
