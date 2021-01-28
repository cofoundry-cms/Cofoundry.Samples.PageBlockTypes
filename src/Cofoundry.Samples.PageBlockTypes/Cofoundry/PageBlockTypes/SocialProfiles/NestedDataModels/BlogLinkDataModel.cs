using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
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
}
