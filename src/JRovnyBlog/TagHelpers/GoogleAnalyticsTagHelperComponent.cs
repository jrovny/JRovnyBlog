using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;

namespace JRovnyBlog.TagHelpers
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        private readonly IConfiguration _configuration;

        public GoogleAnalyticsTagHelperComponent(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                string measurementId = _configuration["GoogleAnalytics:MeasurementId"];

                output.PostContent.AppendHtml(
                    $@"<script async src=""https://www.googletagmanager.com/gtag/js?id={measurementId}""></script>");

                output.PostContent.AppendHtml(@"<script>
                    window.dataLayer = window.dataLayer || [];
                    function gtag(){dataLayer.push(arguments);}
                    gtag('js', new Date());");

                output.PostContent.AppendHtml($@"gtag('config', '{measurementId}');</script>");
            }

            return base.ProcessAsync(context, output);
        }
    }
}