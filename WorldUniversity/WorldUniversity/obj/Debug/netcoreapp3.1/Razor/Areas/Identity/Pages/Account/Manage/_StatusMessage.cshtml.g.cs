#pragma checksum "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "caf0ba0e017fe2d5d40e06cba52017213983ba34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage__StatusMessage), @"mvc.1.0.view", @"/Areas/Identity/Pages/Account/Manage/_StatusMessage.cshtml")]
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
#line 1 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\_ViewImports.cshtml"
using WorldUniversity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\_ViewImports.cshtml"
using WorldUniversity.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\_ViewImports.cshtml"
using WorldUniversity.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\_ViewImports.cshtml"
using WorldUniversity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using WorldUniversity.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using WorldUniversity.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caf0ba0e017fe2d5d40e06cba52017213983ba34", @"/Areas/Identity/Pages/Account/Manage/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e73234993f113890f0350592cd8dc12cd1928d9c", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"448ebb84dace7a02e4b6cfa979045c460ed49922", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b79dd8ae225f150489db79e0829579a6596d46d2", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d329e45d250b68eb57a71b96171cc8625bad0ca7", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 144, "\"", 201, 4);
            WriteAttributeValue("", 152, "alert", 152, 5, true);
            WriteAttributeValue(" ", 157, "alert-", 158, 7, true);
#nullable restore
#line 6 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
WriteAttributeValue("", 164, statusMessageClass, 164, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 183, "alert-dismissible", 184, 18, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n        ");
#nullable restore
#line 8 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
   Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 10 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Areas\Identity\Pages\Account\Manage\_StatusMessage.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
