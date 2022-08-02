﻿using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

[Display(Name = "Blog")]
public class BlogLinkDataModel : INestedDataModel, ISocialProfileDataModel
{
    [Required]
    public string Description { get; set; }

    [PreviewTitle]
    [Url]
    [Required]
    public string Url { get; set; }

    public string GetDescription()
    {
        return Description;
    }

    public string GetUrl()
    {
        return Url;
    }
}
