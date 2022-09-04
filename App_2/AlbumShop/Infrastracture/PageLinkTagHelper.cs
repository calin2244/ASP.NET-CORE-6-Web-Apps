using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using AlbumShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlbumShop.Infrastracture{
    
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper{
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory_){
            urlHelperFactory = urlHelperFactory_;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext{get; set;}

        public PageInfo? PageModel{get; set;}

        public string? PageAction{get; set;}

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues {get; set;} = new Dictionary<string, object>();

        public bool PageClassesEnabled{get; set;} = false;
        public string PageClass{get; set;} = String.Empty;
        public string PageClassNormal{get; set;} = String.Empty;
        public string PageClassSelected{get; set;} = String.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PageModel != null){

                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for(int i = 1; i <= PageModel.TotalPages; ++i){
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["prodPage"] = i;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                    if(PageClassesEnabled){
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }

    
    
}