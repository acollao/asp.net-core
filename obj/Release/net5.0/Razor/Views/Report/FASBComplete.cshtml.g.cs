#pragma checksum "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1aeb3a6abd22b7a021e810cdb2396172047d2d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_FASBComplete), @"mvc.1.0.view", @"/Views/Report/FASBComplete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1aeb3a6abd22b7a021e810cdb2396172047d2d4", @"/Views/Report/FASBComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d3b525bf1aad9597c1ccfde63465d65c706e8b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Report_FASBComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LNTADSpreadsheets.Models.ReportModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-view", "fasbcomplete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Do you wish to delete?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
  
    ViewData["Title"] = "FASB Report Spreadsheets";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style>
    #submitButton {
        background-color: #e8171f;
        color: #fff;
    }

    .submit-progress {
        position: fixed;
        top: 50%;
        left: 50%;
        height: 6em;
        padding-top: 1.75em;
        width: 20em;
        margin-left: -10em;
        padding-left: 1em;
        background-color: black;
        color: white;
        text-align: center;
        -webkit-border-radius: 0.4em;
        -moz-border-radius: 0.4em;
        border-radius: 0.4em;
        box-shadow: 0.4em 0.4em rgba(0,0,0,0.6);
        -webkit-box-shadow: 0.4em 0.4em rgba(0,0,0,0.6);
        -moz-box-shadow: 0.4em 0.4em rgba(0,0,0,0.6);
        z-index: 9;
    }

        .submit-progress i {
            margin-right: 0.5em;
        }

    .modal-body {
        padding: 2rem;
        font-size: 16px;
    }

    .modal-header {
        display: initial;
        font-size: 16px;
    }

    .tCenter {
        text-align: center;
    }

    #uploadBtn, #archiveBt");
            WriteLiteral(@"n {
        background-color: #e8171f;
        color: #fff;
        width: auto;
        float: right;
    }

    #uploadBtn {
        margin-left: 10px;
    }

    thead {
        cursor: pointer;
    }
</style>


<div class=""modal fade"" id=""uploadModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close btn-info"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
                <h4 class=""modal-title"" id=""myModalLabel"">Info</h4>
            </div>
            <div class=""modal-body"" id=""modal-body"">
");
#nullable restore
#line 78 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                 using (Html.BeginForm("Upload", "Report", FormMethod.Post, new { enctype = "multipart/form-data", @id = "frmTransaction" }))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""form-group"">
                        <label class=""control-label"" style=""width:360px;"">&nbsp;Upload a File</label>
                        <br />
                        <input type=""file"" name=""postedFiles"" multiple />
                        <br />
                        <br />
                        <input type=""submit"" class=""form-control btn"" id=""submitButton"" style=""width:115px;"" value=""UPLOAD"" onclick=""return DisplayProgressMessage();"" />
                        <br />
                        <br />
                        <div id=""ViewBagUpload"">
                            <span style=""color:green"">");
#nullable restore
#line 92 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                                                 Write(Html.Raw(ViewBag.UploadMsg));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                        <br />\r\n                        ");
#nullable restore
#line 95 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                   Write(Html.ValidationSummary(true, "", new { @class = "text-danger font-weight-bold", @style = "margin-left: 20px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 97 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <br />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-info"" data-dismiss=""modal"" onclick=""clearModal()"">CANCEL</button>
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal -->
</div>


<div class=""form-group"" id=""aboveID"">
    <h4 style=""float: left;"">FASB Completeness Report</h4>
    <button type=""button"" class=""form-control btn"" id=""uploadBtn"" value=""UPLOAD"" onclick=""displayUploadForm();""><i class=""fas fa-upload""></i> UPLOAD</button>
</div>
<br />
<br />
<table class=""table"" id=""dataTable-Archive"">
    <thead>
        <tr>
            <th>
                ");
#nullable restore
#line 118 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
           Write(Html.DisplayNameFor(model => model.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"tCenter\">\r\n                ");
#nullable restore
#line 121 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
           Write(Html.DisplayNameFor(model => model.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"tCenter\">\r\n                ");
#nullable restore
#line 124 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
           Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"tCenter\">\r\n                ");
#nullable restore
#line 127 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 133 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 137 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
               Write(Html.DisplayFor(modelItem => item.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"tCenter\">\r\n                    ");
#nullable restore
#line 140 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
               Write(Html.DisplayFor(modelItem => item.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"tCenter\">\r\n                    ");
#nullable restore
#line 143 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"tCenter\">\r\n                    ");
#nullable restore
#line 146 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
               Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1aeb3a6abd22b7a021e810cdb2396172047d2d413615", async() => {
                WriteLiteral("<i class=\"fas fa-file-download\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-filename", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 149 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                                                                             WriteLiteral(item.FileName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-filename", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp;|&nbsp;\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1aeb3a6abd22b7a021e810cdb2396172047d2d416134", async() => {
                WriteLiteral("<i class=\"fas fa-trash\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-filename", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 150 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                                                                           WriteLiteral(item.FileName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-filename", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-view", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["view"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 153 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div class=\"submit-progress\" style=\"display: none\" id=\"loader\">\r\n    <i class=\"fa fa-2x fa-spinner fa-spin\"></i>\r\n    <label>Loading. Please wait...</label>\r\n</div>\r\n\r\n<br />\r\n<br />\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 5446, "\"", 5488, 1);
#nullable restore
#line 165 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
WriteAttributeValue("", 5453, Url.Content("~/css/datatable.css"), 5453, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    <script type=\"text/javascript\" src=\"https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n\tvar status = \"");
#nullable restore
#line 174 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
             Write(ViewBag.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n\tvar uploadStatus = \"");
#nullable restore
#line 175 "C:\Users\acollao\source\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Report\FASBComplete.cshtml"
                   Write(ViewBag.UploadMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";

    $(document).ready(function () {

		if (status != """") {
            $('#myModal').modal('show');
		}

		if (uploadStatus != """") {
			displayUploadForm();
		}

		$('#dataTable-Archive').dataTable({
			""order"": [],
		});
	});

	function displayUploadForm()
	{
		$('#uploadModal').modal('show');
	}

	function DisplayProgressMessage() {

		$(""#submitButton"").prop('disabled', true);
		$(""#submitButton"").attr('value', ""Uploading..."");
		$(""#loader"").show();
		var form = $(""#frmTransaction"");
		form.submit();
	}

	function clearModal() {
		$("".validation-summary-errors"").empty();
		$(""#ViewBagUpload"").hide();
	}

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LNTADSpreadsheets.Models.ReportModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
