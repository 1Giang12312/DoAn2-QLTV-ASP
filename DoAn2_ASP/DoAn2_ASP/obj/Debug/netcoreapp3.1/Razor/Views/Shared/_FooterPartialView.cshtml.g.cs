#pragma checksum "C:\Users\Administrator\Desktop\DoAn2-QLTV-ASP\DoAn2_ASP\DoAn2_ASP\Views\Shared\_FooterPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e5aadf42a12fbfa202eeddb4bf57c545544f6d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FooterPartialView), @"mvc.1.0.view", @"/Views/Shared/_FooterPartialView.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrator\Desktop\DoAn2-QLTV-ASP\DoAn2_ASP\DoAn2_ASP\Views\_ViewImports.cshtml"
using DoAn2_ASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\DoAn2-QLTV-ASP\DoAn2_ASP\DoAn2_ASP\Views\_ViewImports.cshtml"
using DoAn2_ASP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e5aadf42a12fbfa202eeddb4bf57c545544f6d4", @"/Views/Shared/_FooterPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c332b5e038121033f553dc5e8ce0299a81a8e624", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__FooterPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/main-logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("footer-logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<footer id=\"footer\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-md-4\">\r\n\r\n                <div class=\"footer-item\">\r\n                    <div class=\"company-brand\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3e5aadf42a12fbfa202eeddb4bf57c545544f6d44507", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <p>????? ??n 2 qu???n l?? th?? vi???n</p>
                    </div>
                </div>

            </div>

            <div class=""col-md-2"">

                <div class=""footer-menu"">
                    <h5>About Us</h5>
                    <ul class=""menu-list"">
                        <li class=""menu-item"">
                            <a href=""#"">vision</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">articles </a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">careers</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">service terms</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">donate</a>
                        </li>
                    </ul>
                </div>

      ");
            WriteLiteral(@"      </div>
            <div class=""col-md-2"">

                <div class=""footer-menu"">
                    <h5>Discover</h5>
                    <ul class=""menu-list"">
                        <li class=""menu-item"">
                            <a href=""#"">Home</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Books</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Authors</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Subjects</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Advanced Search</a>
                        </li>
                    </ul>
                </div>

            </div>
            <div class=""col-md-2"">

                <div class=""footer-menu"">
                    <h5>My a");
            WriteLiteral(@"ccount</h5>
                    <ul class=""menu-list"">
                        <li class=""menu-item"">
                            <a href=""#"">Sign In</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">View Cart</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">My Wishtlist</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Track My Order</a>
                        </li>
                    </ul>
                </div>

            </div>
            <div class=""col-md-2"">

                <div class=""footer-menu"">
                    <h5>Help</h5>
                    <ul class=""menu-list"">
                        <li class=""menu-item"">
                            <a href=""#"">Help center</a>
                        </li>
                        <li class=""menu-item"">
        ");
            WriteLiteral(@"                    <a href=""#"">Report a problem</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Suggesting edits</a>
                        </li>
                        <li class=""menu-item"">
                            <a href=""#"">Contact us</a>
                        </li>
                    </ul>
                </div>

            </div>

        </div>
        <!-- / row -->

    </div>
</footer>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
