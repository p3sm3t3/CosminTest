#pragma checksum "D:\CURS\Goom\AuditInspect.web\Areas\Dashboard\Views\Email\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b299f5a4110080eb265bf0dc6fde041b7c71158"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Dashboard_Views_Email_Error), @"mvc.1.0.view", @"/Areas/Dashboard/Views/Email/Error.cshtml")]
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
#line 1 "D:\CURS\Goom\AuditInspect.web\Areas\Dashboard\Views\_ViewImports.cshtml"
using AuditInspect.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CURS\Goom\AuditInspect.web\Areas\Dashboard\Views\_ViewImports.cshtml"
using AuditInspect.Models.FormModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b299f5a4110080eb265bf0dc6fde041b7c71158", @"/Areas/Dashboard/Views/Email/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8b6b0893e0aae7702de6990fa6fca8fcdcbca68", @"/Areas/Dashboard/Views/_ViewImports.cshtml")]
    public class Areas_Dashboard_Views_Email_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\CURS\Goom\AuditInspect.web\Areas\Dashboard\Views\Email\Error.cshtml"
  
    ViewData["Title"] = "Error";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <div class=""d-flex justify-content-center  mb-3"">            
    <div class=""p-2 "">
           <h1 class=""text-danger"">Error</h1>
           <h2 class=""text-danger"">An error occurred while processing your request. Please try again later.</h2>
    </div>
</div>");
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