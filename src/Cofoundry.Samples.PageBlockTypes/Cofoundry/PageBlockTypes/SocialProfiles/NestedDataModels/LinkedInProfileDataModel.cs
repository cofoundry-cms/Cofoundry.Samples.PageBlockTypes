using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

[Display(Name = "LinkedIn")]
public class LinkedInProfileDataModel : INestedDataModel, ISocialProfileDataModel
{
    [Display(Name = "Profile Id")]
    [PreviewTitle]
    [Required]
    public string ProfileId { get; set; }

    public string GetDescription()
    {
        return "LinkedIn";
    }

    public string GetUrl()
    {
        if (string.IsNullOrWhiteSpace(ProfileId))
        {
            return null;
        }

        return "http://www.linkedin.com/in/" + ProfileId;
    }
}
