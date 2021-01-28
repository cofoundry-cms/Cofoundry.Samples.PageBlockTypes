using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.PageBlockTypes
{
    public class SocialProfilesDataModel : IPageBlockTypeDataModel, IPageBlockTypeDisplayModel
    {
        [Required]
        [NestedDataModelMultiTypeCollection(
            new Type[] {
                typeof(FacebookProfileDataModel),
                typeof(TwitterProfileDataModel),
                typeof(LinkedInProfileDataModel),
                typeof(BlogLinkDataModel)
            },
            IsOrderable = true,
            MinItems = 1,
            MaxItems = 10,
            TitleColumnHeader = "Profile"
            )]
        public ICollection<NestedDataModelMultiTypeItem> SocialProfiles { get; set; }
    }
}
