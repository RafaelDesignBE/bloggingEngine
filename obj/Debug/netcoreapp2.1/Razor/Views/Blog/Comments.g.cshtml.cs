#pragma checksum "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "628146a7f43f6522df83185b24068edd10dfe1f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Comments), @"mvc.1.0.view", @"/Views/Blog/Comments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/Comments.cshtml", typeof(AspNetCore.Views_Blog_Comments))]
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
#line 1 "C:\Users\Rafael\dotnet\bloggingEngine\Views\_ViewImports.cshtml"
using bloggingEngine;

#line default
#line hidden
#line 2 "C:\Users\Rafael\dotnet\bloggingEngine\Views\_ViewImports.cshtml"
using bloggingEngine.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"628146a7f43f6522df83185b24068edd10dfe1f7", @"/Views/Blog/Comments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d6bbb62b43698003cc1f985a55320f7d2770416", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Comments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommentList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 19, true);
            WriteLiteral("<h1>Comments</h1>\r\n");
            EndContext();
#line 3 "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml"
 foreach(var comment in Model.Comments) {

#line default
#line hidden
            BeginContext(83, 22, true);
            WriteLiteral("    <div>\r\n        <p>");
            EndContext();
            BeginContext(106, 15, false);
#line 5 "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml"
      Write(comment.Content);

#line default
#line hidden
            EndContext();
            BeginContext(121, 28, true);
            WriteLiteral("</p>\r\n        <p>Posted by: ");
            EndContext();
            BeginContext(150, 16, false);
#line 6 "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml"
                 Write(comment.AuthorId);

#line default
#line hidden
            EndContext();
            BeginContext(166, 4, true);
            WriteLiteral(" at ");
            EndContext();
            BeginContext(171, 23, false);
#line 6 "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml"
                                      Write(comment.CreatedAtAction);

#line default
#line hidden
            EndContext();
            BeginContext(194, 18, true);
            WriteLiteral("</p>\r\n    </div>\r\n");
            EndContext();
#line 8 "C:\Users\Rafael\dotnet\bloggingEngine\Views\Blog\Comments.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommentList> Html { get; private set; }
    }
}
#pragma warning restore 1591
