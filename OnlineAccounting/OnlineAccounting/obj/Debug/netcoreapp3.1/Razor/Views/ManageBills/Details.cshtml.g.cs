#pragma checksum "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "239545f11b2f52732dd6744d26ee13ebdfebe375"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageBills_Details), @"mvc.1.0.view", @"/Views/ManageBills/Details.cshtml")]
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
#line 1 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\_ViewImports.cshtml"
using OnlineAccounting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\_ViewImports.cshtml"
using OnlineAccounting.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\_ViewImports.cshtml"
using OnlineAccounting.Models.User;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"239545f11b2f52732dd6744d26ee13ebdfebe375", @"/Views/ManageBills/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d48ecfb006b171ffe5997b8873f6cb1879d1952", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageBills_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineAccounting.Models.Purchase.Bill>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Bill</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.vendor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.vendor.CompanyName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SubTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.SubTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TDS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.TDS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
       Write(Html.DisplayFor(model => model.PaymentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <table class=\"table table-striped\">\r\n        <thead>\r\n            <tr class=\"d-table-row\">\r\n                <td>");
#nullable restore
#line 54 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].CustomerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                <td>");
#nullable restore
#line 57 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].ItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 58 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 59 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 60 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 61 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].Tax));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 62 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ItemList[0].Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 66 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
             for (int i = 0; i < Model.ItemList.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 69 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].CustomerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                <td>");
#nullable restore
#line 72 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].ItemId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 73 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 74 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 75 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 76 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].Tax));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 77 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
               Write(Html.DisplayFor(model => model.ItemList[i].Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 79 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239545f11b2f52732dd6744d26ee13ebdfebe37513817", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Users\RAHIL\source\repos\OnlineAccounting\OnlineAccounting\Views\ManageBills\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "239545f11b2f52732dd6744d26ee13ebdfebe37515975", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineAccounting.Models.Purchase.Bill> Html { get; private set; }
    }
}
#pragma warning restore 1591
