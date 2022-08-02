namespace Cofoundry.Web;

public class TextListDisplayModelMapper : IPageBlockTypeDisplayModelMapper<TextListDataModel>
{
    private static string[] LINE_DELIMITERS = new string[] { "\r\n", "\n" };

    public Task MapAsync(
        PageBlockTypeDisplayModelMapperContext<TextListDataModel> context,
        PageBlockTypeDisplayModelMapperResult<TextListDataModel> result
        )
    {
        foreach (var item in context.Items)
        {
            var displayModel = new TextListDisplayModel();
            displayModel.TextListItems = item.DataModel.TextList.Split(LINE_DELIMITERS, StringSplitOptions.None);
            displayModel.Title = item.DataModel.Title;
            displayModel.IsNumbered = item.DataModel.IsNumbered;

            result.Add(item, displayModel);
        }

        return Task.CompletedTask;
    }
}