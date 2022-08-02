using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

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
