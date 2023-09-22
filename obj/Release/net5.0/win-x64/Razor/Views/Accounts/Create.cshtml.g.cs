#pragma checksum "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a356562a85b8097c34b134fca071d41f3b9b138e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts_Create), @"mvc.1.0.view", @"/Views/Accounts/Create.cshtml")]
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
#line 1 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using LNTADSpreadsheets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using LNTADSpreadsheets.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a356562a85b8097c34b134fca071d41f3b9b138e", @"/Views/Accounts/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d3b525bf1aad9597c1ccfde63465d65c706e8b0", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LNTADSpreadsheets.Models.SignUpModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
  
	ViewData["Title"] = "Accounts";

	List<SelectListItem> listUser = new();
	SelectListItem in1 = new();
	in1.Text = "USER";
	in1.Value = "USER";
	listUser.Add(in1);

	SelectListItem in2 = new();
	in2.Text = "ADMIN";
	in2.Value = "ADMIN";
	listUser.Add(in2);


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
	#btnSignup {
		background-color: #e8171f;
		color: #fff;
		width: 120px;
	}

	.modal-body {
		padding: 2rem;
		font-size: 16px;
	}

	.modal-header {
		display: initial;
		font-size: 16px;
	}

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
</style>


<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
	<div class=""modal-dialog"">
		<div class=""modal-content"">");
            WriteLiteral(@"
			<div class=""modal-header"">
				<button type=""button"" class=""close btn-info"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
				<h4 class=""modal-title"" id=""myModalLabel"">Sign Up Summary</h4>
			</div>
			<div class=""modal-body"" id=""modal-body"">
				");
#nullable restore
#line 76 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
           Write(ViewBag.SignUpSuccess);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t");
#nullable restore
#line 77 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t</div>\r\n\t\t\t<div class=\"modal-footer\">\r\n\t\t\t\t<button type=\"button\" class=\"btn btn-info\" data-dismiss=\"modal\">OK</button>\r\n\t\t\t</div>\r\n\t\t</div><!-- /.modal-content -->\r\n\t</div><!-- /.modal -->\r\n</div>\r\n\r\n<div class=\"user signup\">\r\n\t<div class=\"form\">\r\n");
#nullable restore
#line 88 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
         using (Html.BeginForm("Create", "Accounts", FormMethod.Post, new { @role = "form", @id = "frmSignUp" }))
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<h4>Create an account</h4>\r\n\t\t\t<hr />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">Email Address</label>\r\n");
#nullable restore
#line 95 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.TextBoxFor(model => model.EmailAddress, new { @class = "form-control", @required = "required", @placeHolder = "Email Address", @style = "width: 720px;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 96 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.EmailAddress, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">Password</label>\r\n");
#nullable restore
#line 99 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.TextBoxFor(model => model.Password, new { @class = "form-control", @required = "required", @placeHolder = "Password", @type = "password", @autocomplete = "off", @style = "width: 720px;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">Confirm Password</label>\r\n");
#nullable restore
#line 103 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.TextBoxFor(model => model.ConfirmPassword, new { @class = "form-control", @required = "required", @placeHolder = "Confirm Password", @type = "password", @autocomplete = "off", @style = "width: 720px;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 104 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">First Name</label>\r\n");
#nullable restore
#line 107 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.TextBoxFor(model => model.FirstName, new { @class = "form-control", @required = "required", @placeHolder = "First Name", @style = "width: 720px;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">Last Name</label>\r\n");
#nullable restore
#line 111 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.TextBoxFor(model => model.LastName, new { @class = "form-control", @required = "required", @placeHolder = "Last Name", @style = "width: 720px;" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 112 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.ValidationMessageFor(m => m.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<label class=\"control-label\" style=\"width:360px;\">Select Role</label>\r\n\t\t\t<br />\r\n");
#nullable restore
#line 116 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
       Write(Html.DropDownList("userRole", listUser, null, new { @class = "form-control", @style = "width:360px;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<br />\r\n\t\t\t<input type=\"submit\" id=\"btnSignup\" value=\"CREATE\" class=\"form-control btn\" onclick=\"SubmitForm()\" />\r\n\t\t\t<br />\r\n");
#nullable restore
#line 121 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
                                                                                                                                 
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n</div>\r\n<br />\r\n<br />\r\n<div class=\"submit-progress\" style=\"display: none\" id=\"loader\">\r\n\t<i class=\"fa fa-2x fa-spinner fa-spin\"></i>\r\n\t<label>Loading. Please wait...</label>\r\n</div>\r\n\r\n\r\n<script type=\"text/javascript\">\r\n\tvar errorModal = \"");
#nullable restore
#line 134 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
                 Write(ViewBag.ModelError);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n\tvar signUpSuccess = \"");
#nullable restore
#line 135 "E:\repos\ln-tad-spreadsheets-web-app\LNTADSpreadsheets\Views\Accounts\Create.cshtml"
                    Write(ViewBag.SignUpSuccess);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";

	$(document).ready(function () {

        if (errorModal == ""On"") {
            $('#myModal').modal('show');
        }

		if (signUpSuccess == ""Registration successful."") {
			$('#myModal').modal('show');
		}

	});

	function SubmitForm() {

		$(""#submitButton"").prop('disabled', true);
		$(""#submitButton"").attr('value', ""Creating..."");
		$(""#loader"").show();
		var form = $(""#frmSignUp"");
		form.submit();
	}

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LNTADSpreadsheets.Models.SignUpModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
