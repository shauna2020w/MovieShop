#pragma checksum "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e118d0aa80f50457849f118d15f5e308ab9be4bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e118d0aa80f50457849f118d15f5e308ab9be4bd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApplicationCore.Models.Response.MovieCardResponseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "HomePage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"rounded\">\r\n    <div class=\"container-fluid bg-light\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\Home\Index.cshtml"
             foreach (var movie in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-2 col-lg-3\">\r\n                    ");
#nullable restore
#line 15 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\Home\Index.cshtml"
               Write(await Html.PartialAsync("_MovieCard", movie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 17 "D:\ShaunaWorld\Antra\wk5\MovieShop\MovieShop\MovieShop.MVC\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>

    <nav aria-label=""Page navigation example"">
        <ul class=""pagination"">
            <li class=""page-item"">
                <a class=""page-link"" href=""#"" aria-label=""Previous"">
                    <span aria-hidden=""true"">&laquo;</span>
                </a>
            </li>
            <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
            <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
            <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
            <li class=""page-item"">
                <a class=""page-link"" href=""#"" aria-label=""Next"">
                    <span aria-hidden=""true"">&raquo;</span>
                </a>
            </li>
        </ul>
    </nav>

</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApplicationCore.Models.Response.MovieCardResponseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591