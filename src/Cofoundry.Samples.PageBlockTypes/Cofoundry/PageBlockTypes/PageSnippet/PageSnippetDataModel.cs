﻿using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

public class PageSnippetDataModel : IPageBlockTypeDataModel
{
    [Display(Name = "Page", Description = "The page to display a summary snippet for.")]
    [Page]
    public int PageId { get; set; }
}