#pragma checksum "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Instructors_Index), @"mvc.1.0.view", @"/Views/Instructors/Index.cshtml")]
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
#line 2 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\_ViewImports.cshtml"
using WorldUniversity.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1fd83914d2f197bf719f8fe3f8e15c50d5a131f", @"/Views/Instructors/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e73234993f113890f0350592cd8dc12cd1928d9c", @"/_ViewImports.cshtml")]
    public class Views_Instructors_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WorldUniversity.ViewModels.Instructors.InstructorIndexData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn text-center btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/custom/PrintDataTable.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
  
    ViewData["Title"] = "Instructors";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f7265", async() => {
                WriteLiteral("\r\n            Create New Instructor\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<div class=""container-fluid"" id=""print"">
    <!-- DataTales Example -->
    <div class=""card shadow mb-4"">
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered table-hover font-italic "" id=""example"" width=""100%"">
                    <thead>
                        <tr>
                            <th colspan=""9"" class=""text-center"">Instructors</th>
                        </tr>
                        <tr class=""bg-primary text-gray-400"">
                            <th class=""text-center align-middle"">First Name</th>
                            <th class=""text-center align-middle"">Last Name</th>
                            <th class=""text-center align-middle"">Hire Date</th>
                            <th class=""text-center align-middle"">Office</th>
                            <th class=""text-center align-middle"">Courses</th>
                            <th class=""text-center align-middle"">Select</th>
        ");
            WriteLiteral(@"                    <th class=""text-center align-middle"">Course Details</th>
                            <th class=""text-center align-middle"">Edit Course</th>
                            <th class=""text-center align-middle"">Delete Course</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 37 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                          
                            foreach (var item in Model.Instructors)
                            {
                                string selectedRow = "";
                                if (item.ID == (int?)ViewData["InstructorId"])
                                {
                                    selectedRow = "success";
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("class", " class=\"", 2086, "\"", 2106, 1);
#nullable restore
#line 45 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
WriteAttributeValue("", 2094, selectedRow, 2094, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <th class=\"text-center align-middle\">");
#nullable restore
#line 46 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                    Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th class=\"text-center align-middle\">");
#nullable restore
#line 47 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                    Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th class=\"text-center align-middle\">");
#nullable restore
#line 48 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                    Write(item.HireDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <th class=\"text-center align-middle\">\r\n");
#nullable restore
#line 50 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                         if (item.OfficeAssignment != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                       Write(item.OfficeAssignment.Location);

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                           
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </th>\r\n                                    <th class=\"text-center align-middle\">\r\n");
#nullable restore
#line 56 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                          
                                            foreach (var course in item.CourseAssignments)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                           Write(course.Course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 60 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </th>\r\n                                    <th class=\"text-center\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f14632", async() => {
                WriteLiteral("\r\n                                            Select\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                WriteLiteral(item.ID);

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
            WriteLiteral("\r\n                                    </th>\r\n                                    <th class=\"text-center\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f17241", async() => {
                WriteLiteral("\r\n                                            Details\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                  WriteLiteral(item.ID);

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
            WriteLiteral("\r\n                                    </th>\r\n                                    <th class=\"text-center\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f19853", async() => {
                WriteLiteral("\r\n                                            Edit\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                               WriteLiteral(item.ID);

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
            WriteLiteral("\r\n                                    </th>\r\n                                    <th class=\"text-center\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f22459", async() => {
                WriteLiteral("\r\n                                            Delete\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                 WriteLiteral(item.ID);

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
            WriteLiteral("\r\n                                    </th>\r\n                                </tr>\r\n");
#nullable restore
#line 88 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                    <tfoot>
                        <tr>
                            <th colspan=""9"" class=""text-right""></th>
                        </tr>
                        <tr>
                            <th colspan=""8"" class=""text-right"">Total Number Of Courses</th>
                            <th colspan=""1"" class=""text-center"">");
#nullable restore
#line 97 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                           Write(Model.Instructors.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n                    </tfoot>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 106 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
 if (Model.Courses != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid"" id=""print"">
        <!-- DataTales Example -->
        <div class=""card shadow mb-4"">
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover font-italic "" id=""example"" width=""100%"">
                        <thead>
                            <tr>
                                <th colspan=""4"" class=""text-center"">Courses Taught by Selected Instructor</th>
                            </tr>
                            <tr class=""bg-primary text-gray-400"">
                                <th class=""text-center align-middle"">Number</th>
                                <th class=""text-center align-middle"">Title</th>
                                <th class=""text-center align-middle"">Department</th>
                                <th class=""text-center align-middle"">Select</th>
                            </tr>
                        </thead>
                        <tb");
            WriteLiteral("ody>\r\n");
#nullable restore
#line 126 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                              
                                foreach (var item in Model.Courses)
                                {
                                    string selectedRow = "";
                                    if (item.Id == (int?)ViewData["Id"])
                                    {
                                        selectedRow = "success";
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr");
            BeginWriteAttribute("class", " class=\"", 6931, "\"", 6951, 1);
#nullable restore
#line 134 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
WriteAttributeValue("", 6939, selectedRow, 6939, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <td class=\"text-center align-middle\">\r\n                                            ");
#nullable restore
#line 136 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"text-center align-middle\">\r\n                                            ");
#nullable restore
#line 139 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"text-center align-middle\">\r\n                                            ");
#nullable restore
#line 142 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                       Write(item.Department.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"text-center\">\r\n                                            ");
#nullable restore
#line 145 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                       Write(Html.ActionLink("Select", "Index", new { courseId = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 148 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"

                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan=""4"" class=""text-right""></th>
                            </tr>
                            <tr>
                                <th colspan=""3"" class=""text-right"">Total Number Of Courses Taught by Selected Instructor</th>
                                <th colspan=""1"" class=""text-center"">");
#nullable restore
#line 158 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                               Write(Model.Courses.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            </tr>\r\n                        </tfoot>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 166 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 167 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
 if (Model.Enrollments != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid"" id=""print"">
        <!-- DataTales Example -->
        <div class=""card shadow mb-4"">
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover font-italic "" id=""example"" width=""100%"">
                        <thead>
                            <tr>
                                <th colspan=""3"" class=""text-center"">Students Enrolled in Selected Course</th>
                            </tr>
                            <tr class=""bg-primary text-gray-400"">
                                <th class=""text-center align-middle"">Name</th>
                                <th class=""text-center align-middle"">Grade</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 186 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                              
                                foreach (var item in Model.Enrollments)
                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th class=\"text-center align-middle\">");
#nullable restore
#line 191 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                        Write(item.Student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 191 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                                                Write(item.Student.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th class=\"text-center align-middle\">");
#nullable restore
#line 192 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                                        Write(item.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        <th></th>\r\n                                    </tr>\r\n");
#nullable restore
#line 195 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan=""3"" class=""text-right""></th>
                            </tr>
                            <tr>
                                <th colspan=""2"" class=""text-right"">Total Number Of Courses Taught by Selected Instructor</th>
                                <th colspan=""1"" class=""text-center"">");
#nullable restore
#line 204 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
                                                               Write(Model.Enrollments.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            </tr>\r\n                        </tfoot>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 212 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1fd83914d2f197bf719f8fe3f8e15c50d5a131f36286", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 215 "C:\Users\shadd\Desktop\TortoiseRepository\WorldUniversity\WorldUniversity\Views\Instructors\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WorldUniversity.ViewModels.Instructors.InstructorIndexData> Html { get; private set; }
    }
}
#pragma warning restore 1591
