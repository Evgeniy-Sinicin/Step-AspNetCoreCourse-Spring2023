using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Shop.Presentation.Web.ShopTagHelpers
{
    [HtmlTargetElement(Attributes = "is-diplayed")]
    public class IsDisplayedTagHelper : TagHelper
    {
        public bool IsDisplayed { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsDisplayed)
            {
                output.SuppressOutput();
            }
        }
    }
}
