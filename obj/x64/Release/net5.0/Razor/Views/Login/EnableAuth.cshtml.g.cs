#pragma checksum "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16b88794e0ce501066725687ab2d5574fc7710dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_EnableAuth), @"mvc.1.0.view", @"/Views/Login/EnableAuth.cshtml")]
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
#line 1 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using LNTADSpreadsheets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using LNTADSpreadsheets.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16b88794e0ce501066725687ab2d5574fc7710dd", @"/Views/Login/EnableAuth.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d3b525bf1aad9597c1ccfde63465d65c706e8b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_EnableAuth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <img");
            BeginWriteAttribute("src", " src=", 147, "", 176, 1);
#nullable restore
#line 8 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml"
WriteAttributeValue("", 152, ViewBag.BarcodeImageUrl, 152, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"300\" height=\"300\" />\r\n</div>\r\n<div>\r\n    Manual Setup Code : ");
#nullable restore
#line 11 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml"
                   Write(ViewBag.SetupCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div>Manual Key 2: ");
#nullable restore
#line 13 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml"
              Write(ViewData["SetupCode"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div>\r\n");
#nullable restore
#line 15 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml"
     using (Html.BeginForm("TwoFactorAuthenticate", "Login", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"text\" name=\"otpcode\" />\r\n    <input type=\"submit\" class=\"btn btn-success\" />\r\n");
#nullable restore
#line 19 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\EnableAuth.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
