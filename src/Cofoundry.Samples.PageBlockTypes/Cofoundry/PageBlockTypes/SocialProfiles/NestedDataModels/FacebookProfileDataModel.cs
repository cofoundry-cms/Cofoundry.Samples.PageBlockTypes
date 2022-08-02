using System.ComponentModel.DataAnnotations;

namespace Cofoundry.Samples.PageBlockTypes;

[Display(Name = "Facebook")]
public class FacebookProfileDataModel : INestedDataModel, ISocialProfileDataModel
{
    [Display(Name = "Facebook Id")]
    [PreviewTitle]
    [Required]
    public string FacebookId { get; set; }

    public string GetDescription()
    {
        return "Facebook";
    }

    public string GetUrl()
    {
        if (string.IsNullOrWhiteSpace(FacebookId))
        {
            return null;
        }

        return "https://www.facebook.com/" + FacebookId;
    }
}
