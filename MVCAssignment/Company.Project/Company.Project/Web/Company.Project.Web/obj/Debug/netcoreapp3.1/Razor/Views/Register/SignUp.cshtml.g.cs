#pragma checksum "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abac9ce0c55f9d781b6aba1ed32c00831efe50aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_SignUp), @"mvc.1.0.view", @"/Views/Register/SignUp.cshtml")]
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
#line 1 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abac9ce0c55f9d781b6aba1ed32c00831efe50aa", @"/Views/Register/SignUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2551b49126852e4045629e5ce460bf891121aad7", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_SignUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company.Project.Web.Models.RegisterUserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
   
    ViewData["Title"] = "SignUp page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""vh-100 bg-image"" style=""background-image: url('https://mdbcdn.b-cdn.net/img/Photos/new-templates/search-box/img4.webp');"">
    <div class=""mask d-flex align-items-center h-100 gradient-custom-3"">
        <div class=""container h-100"">
            <div class=""row d-flex justify-content-center align-items-center h-100"">
                <div class=""col-12 col-md-9 col-lg-7 col-xl-6"">
                    <div class=""card"" style=""border-radius: 15px;"">
                        <div class=""card-body p-5"">


                            <h2 class=""text-uppercase text-center mb-5"">Create an account</h2>

");
#nullable restore
#line 18 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                             using (Html.BeginForm("SignUp", "Register", FormMethod.Post))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"form-outline mb-4\">\r\n                                    <label class=\"form-label\" for=\"form3Example1cg\">User Name</label>\r\n                                    ");
#nullable restore
#line 24 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.EditorFor(model => model.UserName, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 25 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.ValidationMessageFor(model => model.UserName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </div>\r\n");
            WriteLiteral("                                <div class=\"form-outline mb-4\">\r\n                                    <label class=\"form-label\" for=\"form3Example3cg\">Your Email</label>\r\n                                    ");
#nullable restore
#line 31 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.EditorFor(model => model.EmailId, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 32 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.ValidationMessageFor(model => model.EmailId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n");
            WriteLiteral("                                <div class=\"form-outline mb-4\">\r\n                                    <label class=\"form-label\" for=\"form3Example4cg\">Password</label><br />\r\n                                    ");
#nullable restore
#line 37 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.PasswordFor(model => model.Password, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 38 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n");
            WriteLiteral("                                <div class=\"form-outline mb-4\">\r\n                                    <label class=\"form-label\" for=\"form3Example4cdg\">Repeat your password</label><br />\r\n                                    ");
#nullable restore
#line 43 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.PasswordFor(model => model.ConfirmPassword, new { htmlAttributes = new { @class = "form-control form-control-lg" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 44 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                               Write(Html.ValidationMessageFor(model => model.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n");
            WriteLiteral(@"                                <div class=""d-flex justify-content-center"">
                                    <input type=""submit"" value=""Register"" class=""btn btn-success btn-block btn-lg gradient-custom-4 text-body""/>
                                </div>
");
#nullable restore
#line 50 "D:\CloneFile\santosh-kumar-singh\Company.Project\Web\Company.Project.Web\Views\Register\SignUp.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company.Project.Web.Models.RegisterUserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
