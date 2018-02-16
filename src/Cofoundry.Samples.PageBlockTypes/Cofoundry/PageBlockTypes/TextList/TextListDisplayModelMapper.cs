using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cofoundry.Domain;

namespace Cofoundry.Web
{
    public class TextListDisplayModelMapper : IPageBlockTypeDisplayModelMapper<TextListDataModel>
    {
        private static string[] LINE_DELIMITERS = new string[] { "\r\n", "\n" };

        public Task<IEnumerable<PageBlockTypeDisplayModelMapperOutput>> MapAsync(
            IReadOnlyCollection<PageBlockTypeDisplayModelMapperInput<TextListDataModel>> inputCollection, 
            PublishStatusQuery publishStatusQuery
            )
        {
            return Task.FromResult(Map(inputCollection));
        }

        private IEnumerable<PageBlockTypeDisplayModelMapperOutput> Map(IEnumerable<PageBlockTypeDisplayModelMapperInput<TextListDataModel>> inputs)
        {
            foreach (var input in inputs)
            {
                var output = new TextListDisplayModel();
                output.TextListItems = input.DataModel.TextList.Split(LINE_DELIMITERS, StringSplitOptions.None);
                output.Title = input.DataModel.Title;
                output.IsNumbered = input.DataModel.IsNumbered;

                yield return input.CreateOutput(output);
            }
        }
    }
}