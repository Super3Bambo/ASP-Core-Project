#pragma checksum "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "005a5f2d7932c5f1d9924390a52c83e9a5cd682b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Animes_Details), @"mvc.1.0.view", @"/Views/Animes/Details.cshtml")]
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
#line 1 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\_ViewImports.cshtml"
using ASPProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\_ViewImports.cshtml"
using ASPProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"005a5f2d7932c5f1d9924390a52c83e9a5cd682b", @"/Views/Animes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d41f83fc5770df93c17f74e740fea1adb9d8a5f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Animes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASPProject.Models.Anime>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
  
    ViewData["Title"] = "Details";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 8 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n<div>\n    <h4>Anime</h4>\n    <hr />\n");
            WriteLiteral("        <div class=\"w-50\">\n            <dl class=\"row\">\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 17 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
#nullable restore
#line 20 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 24 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n");
#nullable restore
#line 27 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
                     if (Model.Rating == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label>-</label> ");
#nullable restore
#line 29 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
                         }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
   Write(Html.DisplayFor(model => model.Rating));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </dd>\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 35 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.ReleaseYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
#nullable restore
#line 38 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayFor(model => model.ReleaseYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 41 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
#nullable restore
#line 44 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 47 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Studios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
#nullable restore
#line 50 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayFor(model => model.Studios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt class=\"col-sm-2\">\n                    ");
#nullable restore
#line 53 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Plot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd class=\"col-sm-10\">\n                    ");
#nullable restore
#line 56 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
               Write(Html.DisplayFor(model => model.Plot));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n\n                <dt>\n                <dd>\n   \n                </dd>\n\n\n            </dl>\n\n\n        </div>\n        </div>\n\n    \n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "005a5f2d7932c5f1d9924390a52c83e9a5cd682b10704", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
                                                WriteLiteral(Model.ID);

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
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "005a5f2d7932c5f1d9924390a52c83e9a5cd682b12945", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\101\source\repos\ASPProject\ASPProject\Views\Animes\Details.cshtml"
                                                    WriteLiteral(Model.ID);

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
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "005a5f2d7932c5f1d9924390a52c83e9a5cd682b15192", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASPProject.Models.Anime> Html { get; private set; }
    }
}
#pragma warning restore 1591
