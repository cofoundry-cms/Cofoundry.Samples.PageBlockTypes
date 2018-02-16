using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class PageListDisplayModel : IPageBlockTypeDisplayModel
    {
        public ICollection<PageRoute> Pages { get; set; }
    }
}