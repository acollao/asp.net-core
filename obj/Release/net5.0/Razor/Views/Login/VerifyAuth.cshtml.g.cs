#pragma checksum "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc8ed4fa4fa85e39e1f93f8093e36521e2c8b66a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_VerifyAuth), @"mvc.1.0.view", @"/Views/Login/VerifyAuth.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc8ed4fa4fa85e39e1f93f8093e36521e2c8b66a", @"/Views/Login/VerifyAuth.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d3b525bf1aad9597c1ccfde63465d65c706e8b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_VerifyAuth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EnableAuth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
  
    ViewData["Title"] = "Enable 2FA";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Modal -->
<div class=""modal fade"" id=""authModal"" data-backdrop=""static"" data-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
  <div class=""modal-dialog"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"" id=""staticBackdropLabel"">Enter OTP Below</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"" hidden>&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
");
#nullable restore
#line 18 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
         if (@ViewBag.ErrorMessage != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-danger\">\r\n                ");
#nullable restore
#line 21 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
           Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 23 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
         using (Html.BeginForm("TwoFactorAuthenticate", "Login", FormMethod.Post))
        {
          

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
     Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"text\" name=\"otpcode\" />\r\n            <input type=\"submit\" class=\"btn btn-success\" />\r\n");
#nullable restore
#line 29 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("      </div>\r\n      <div class=\"modal-footer\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc8ed4fa4fa85e39e1f93f8093e36521e2c8b66a7353", async() => {
                WriteLiteral("\r\n              Enable 2FA\r\n          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n\tvar status = \"");
#nullable restore
#line 41 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
             Write(ViewBag.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n\tvar uploadStatus = \"");
#nullable restore
#line 42 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Login\VerifyAuth.cshtml"
                   Write(ViewBag.UploadMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n\r\n    $(document).ready(function () {\r\n\t\tdisplay2FAForm();\r\n\t});\r\n\r\n\tfunction display2FAForm()\r\n\t{\r\n\t\t$(\'#authModal\').modal(\'show\');\r\n\t}\r\n\r\n\tfunction clearModal() {\r\n\t\t$(\"#authModal\").hide();\r\n\t}\r\n\r\n</script>");
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
