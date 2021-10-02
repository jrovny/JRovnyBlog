using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace JRovnyBlog.TagHelpers
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        string _measurementId = "G-NFBCMHEYCK";

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(
                    $@"<script async src=""https://www.googletagmanager.com/gtag/js?id={_measurementId}""></script>");

                output.PostContent.AppendHtml(@"<script>
                    window.dataLayer = window.dataLayer || [];
                    function gtag(){dataLayer.push(arguments);}
                    gtag('js', new Date());");

                output.PostContent.AppendHtml($@"gtag('config', '{_measurementId}');</script>");
            }

            return base.ProcessAsync(context, output);
        }
    }
}