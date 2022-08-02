﻿using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

[Display(Name = "Twitter")]
public class TwitterProfileDataModel : INestedDataModel, ISocialProfileDataModel
{
    [PreviewTitle]
    [Required]
    public string TwitterHandle { get; set; }

    public string GetDescription()
    {
        return "Twitter";
    }

    public string GetUrl()
    {
        if (string.IsNullOrWhiteSpace(TwitterHandle))
        {
            return null;
        }

        return "https://twitter.com/" + TwitterHandle;
    }
}
