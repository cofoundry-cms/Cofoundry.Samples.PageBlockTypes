using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
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
}
