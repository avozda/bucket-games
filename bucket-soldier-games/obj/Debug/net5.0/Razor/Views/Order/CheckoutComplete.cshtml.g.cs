#pragma checksum "/Users/adamvozda/Projects/bucket-games-Vozda2.0 10.05.28/bucket-soldier-games/Views/Order/CheckoutComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10c918100e2b97de17b70372eb6374c8bc29759c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CheckoutComplete), @"mvc.1.0.view", @"/Views/Order/CheckoutComplete.cshtml")]
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
#line 1 "/Users/adamvozda/Projects/bucket-games-Vozda2.0 10.05.28/bucket-soldier-games/Views/_ViewImports.cshtml"
using bucket_soldier_games;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/adamvozda/Projects/bucket-games-Vozda2.0 10.05.28/bucket-soldier-games/Views/_ViewImports.cshtml"
using bucket_soldier_games.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/adamvozda/Projects/bucket-games-Vozda2.0 10.05.28/bucket-soldier-games/Views/_ViewImports.cshtml"
using bucket_soldier_games.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10c918100e2b97de17b70372eb6374c8bc29759c", @"/Views/Order/CheckoutComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3aefd2c30ab7e657ea019fb5c6237767d4a25", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CheckoutComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\n    <h1>\n        ");
#nullable restore
#line 3 "/Users/adamvozda/Projects/bucket-games-Vozda2.0 10.05.28/bucket-soldier-games/Views/Order/CheckoutComplete.cshtml"
   Write(ViewBag.CheckoutCompleteMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </h1>\n    </div >\n");
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
