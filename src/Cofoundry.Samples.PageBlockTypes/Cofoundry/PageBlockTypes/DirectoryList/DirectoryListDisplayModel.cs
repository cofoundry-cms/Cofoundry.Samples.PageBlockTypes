using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class DirectoryListDisplayModel : IPageBlockTypeDisplayModel
    {
        public IPagedQueryResult<PageSummary> Pages { get; set; }
    }
}