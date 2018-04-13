using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class CarouselSlideDisplayModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public ImageAssetRenderDetails Image { get; set; }
    }
}
