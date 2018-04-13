using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class CarouselDisplayModel : IPageBlockTypeDisplayModel
    {
        public ICollection<CarouselSlideDisplayModel> Slides { get; set; }
    }
}
