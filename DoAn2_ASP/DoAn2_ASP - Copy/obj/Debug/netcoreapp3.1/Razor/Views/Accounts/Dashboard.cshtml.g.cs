#pragma checksum "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a76fe184e9f7e0306002652810eb725767f2bd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts_Dashboard), @"mvc.1.0.view", @"/Views/Accounts/Dashboard.cshtml")]
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
#line 1 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\_ViewImports.cshtml"
using DoAn2_ASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\_ViewImports.cshtml"
using DoAn2_ASP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a76fe184e9f7e0306002652810eb725767f2bd2", @"/Views/Accounts/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c332b5e038121033f553dc5e8ce0299a81a8e624", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAn2_ASP.Models.TblSinhVien>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Shared/_Layout.cshtml";
    List<TblDonMuonSach> DanhSachDonSach = ViewBag.DonSach;
    List<TblSinhVien> lsDSSinhVien = ViewBag.SinhVien;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Dashboard</h1>\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a76fe184e9f7e0306002652810eb725767f2bd23726", async() => {
                WriteLiteral(@"
    <title>Bootstrap Example</title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a76fe184e9f7e0306002652810eb725767f2bd25142", async() => {
                WriteLiteral(@"

    <div class=""container"">
        <h2>Dynamic Tabs</h2>
        <ul class=""nav nav-tabs"">
            <li class=""active""><a data-toggle=""tab"" href=""#Profile"">Thông tin cá nhân</a></li>
            <li><a data-toggle=""tab"" href=""#DSSach"">Danh sách sách</a></li>
            <li><a data-toggle=""tab"" href=""#menu2"">Menu 2</a></li>
            <li><a data-toggle=""tab"" href=""#menu3"">Menu 3</a></li>
        </ul>

        <div class=""tab-content"">
            <div id=""Profile"" class=""tab-pane fade in active"">
                <h3>Thông tin cá nhân</h3>
                <div class=""col-lg-4"">
                    <div class=""card mb-4"">
                        <div class=""card-body text-center"">
                            <img src=""https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp"" alt=""avatar""
                                 class=""rounded-circle img-fluid"" style=""width: 150px;"">
                            <h5 class=""my-3"">Tên: ");
#nullable restore
#line 40 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                             Write(Html.DisplayFor(model => model.StTenSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <p class=\"text-muted mb-1\">Khoa: ");
#nullable restore
#line 41 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                        Write(Html.DisplayFor(model => model.StMaKhoaNavigation.StTenKhoa));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <p class=\"text-muted mb-4\">Số lần bị phạt: ");
#nullable restore
#line 42 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                                  Write(Html.DisplayFor(model => model.InSoLanBiPhat));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                        </div>
                    </div>
                    <div class=""card mb-4 mb-lg-0"">
                    </div>
                </div>
                <div class=""col-lg-8"">
                    <div class=""card mb-4"">
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 53 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.StTenSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\">");
#nullable restore
#line 56 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                          Write(Html.DisplayFor(model => model.StTenSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 62 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.StMaSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\">");
#nullable restore
#line 65 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                          Write(Html.DisplayFor(model => model.StMaSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 71 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.StMaKhoaNavigation));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\">");
#nullable restore
#line 74 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                          Write(Html.DisplayFor(model => model.StMaKhoaNavigation.StTenKhoa));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 80 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.StGmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\"> ");
#nullable restore
#line 83 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                           Write(Html.DisplayFor(model => model.StGmail));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 89 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.StSoDienThoai));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\"> ");
#nullable restore
#line 92 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                           Write(Html.DisplayFor(model => model.StSoDienThoai));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <p class=""mb-0"">");
#nullable restore
#line 98 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                               Write(Html.DisplayNameFor(model => model.InSoLanBiPhat));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-sm-9\">\r\n                                    <p class=\"text-muted mb-0\"> ");
#nullable restore
#line 101 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
                                                           Write(Html.DisplayFor(model => model.InSoLanBiPhat));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                </div>
                            </div>

                            <hr>
                        </div>
                    </div>
                </div>
                </div>
            <div id=""DSSach"" class=""tab-pane fade"">
                <h3>Danh sách sách</h3>
                ");
#nullable restore
#line 112 "C:\Users\Administrator\Desktop\DoAn2_ASP\DoAn2_ASP\Views\Accounts\Dashboard.cshtml"
           Write(await Html.PartialAsync("_DonSachPartialView", lsDSSinhVien));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
                <div id=""menu2"" class=""tab-pane fade"">
                    <h3>Menu 2</h3>
                    <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
                </div>
            </div>
    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $("".xemdonhang"").click(function () {
                var madonhang = $(this).attr(""data-madonhang"")
                $.ajax({
                    url: '/DonHang/Details',
                    datatype: ""json"",
                    type: ""POST"",
                    data: { id: madonhang },
                    async: true,
                    success: function (results) {
                        $(""#records_table"").html("""");
                        $(""#records_table"").html(results);
                    },
                    error: function (xhr) {
                        alert('error');
                    }
                });
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DoAn2_ASP.Models.TblSinhVien> Html { get; private set; }
    }
}
#pragma warning restore 1591