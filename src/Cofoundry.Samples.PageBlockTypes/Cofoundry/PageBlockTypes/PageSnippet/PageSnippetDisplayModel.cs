using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class PageSnippetDisplayModel : IPageBlockTypeDisplayModel
    {
        public PageRenderDetails Page { get; set; }

        public string Snippet { get; set; }
    }
}