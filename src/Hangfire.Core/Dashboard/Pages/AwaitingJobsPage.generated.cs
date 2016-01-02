﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.States;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class AwaitingJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
  
    Layout = new LayoutPage("Awaiting Jobs");

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    List<string> jobIds = null;
    Pager pager = null;

    using (var connection = Storage.GetConnection())
    {
        var storageConnection = connection as JobStorageConnection;

        if (storageConnection != null)
        {
            pager = new Pager(from, perPage, storageConnection.GetSetCount("awaiting"));
            jobIds = storageConnection.GetRangeFromSet("awaiting", pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 34 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
   Write(Html.JobsSidebar());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"page-header\">Awaitin" +
"g Jobs</h1>\r\n\r\n");


            
            #line 39 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
         if (jobIds == null)
        {

            
            #line default
            #line hidden
WriteLiteral(@"            <div class=""alert alert-warning"">
                <h4>Continuations are working, but this page can't be displayed</h4>
                <p>
                    Don't worry, continuations are working as expected. But your current job storage does not
                    support some queries required to show this page. Please try to update your storage or wait
                    until the full command set is implemented.
                </p>
            </div>
");


            
            #line 49 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }
        else if (jobIds.Count > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\r\n                <div class=\"btn-toolbar b" +
"tn-toolbar-top\">\r\n                    <button class=\"js-jobs-list-command btn bt" +
"n-sm btn-primary\"\r\n                            data-url=\"");


            
            #line 55 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                 Write(Url.To("/jobs/awaiting/enqueue"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Enqueueing..."">
                        <span class=""glyphicon glyphicon-repeat""></span>
                        Enqueue jobs
                    </button>

                    <button class=""js-jobs-list-command btn btn-sm btn-default""
                            data-url=""");


            
            #line 62 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                 Write(Url.To("/jobs/awaiting/delete"));

            
            #line default
            #line hidden
WriteLiteral(@"""
                            data-loading-text=""Deleting...""
                            data-confirm=""Do you really want to DELETE ALL selected jobs?"">
                        <span class=""glyphicon glyphicon-remove""></span>
                        Delete selected
                    </button>

                    ");


            
            #line 69 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
               Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral(@"
                </div>

                <table class=""table table-hover"">
                    <thead>
                        <tr>
                            <th class=""min-width"">
                                <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                            </th>
                            <th class=""min-width"">Id</th>
                            <th>Job</th>
                            <th class=""min-width"">Options</th>
                            <th class=""min-width"">Parent</th>
                            <th class=""align-right"">Created</th>
                        </tr>
                    </thead>
                    <tbody>
");


            
            #line 86 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                         foreach (var jobId in jobIds)
                        {
                            JobData jobData;
                            StateData stateData;
                            StateData parentStateData = null;

                            using (var connection = Storage.GetConnection())
                            {
                                jobData = connection.GetJobData(jobId);
                                stateData = connection.GetStateData(jobId);

                                if (stateData != null && stateData.Name == AwaitingState.StateName)
                                {
                                    parentStateData = connection.GetStateData(stateData.Data["ParentId"]);
                                }
                            }


            
            #line default
            #line hidden
WriteLiteral("                            <tr class=\"js-jobs-list-row ");


            
            #line 103 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                    Write(jobData != null ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                <td>\r\n                                    <in" +
"put type=\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 105 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                                                                         Write(jobId);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                                </td>\r\n                                <td " +
"class=\"min-width\">\r\n                                    ");


            
            #line 108 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                               Write(Html.JobIdLink(jobId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");


            
            #line 110 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                 if (jobData == null)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <td colspan=\"2\"><em>Job expired.</em></td>\r\n");


            
            #line 113 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <td>\r\n                                       " +
" ");


            
            #line 117 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                   Write(Html.JobNameLink(jobId, jobData.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n");



WriteLiteral("                                    <td class=\"min-width\">\r\n");


            
            #line 120 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                         if (stateData != null && stateData.Data.ContainsKey("Options") && !String.IsNullOrWhiteSpace(stateData.Data["Options"]))
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <code>");


            
            #line 122 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                             Write(stateData.Data["Options"]);

            
            #line default
            #line hidden
WriteLiteral("</code>\r\n");


            
            #line 123 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>N/A</em>\r\n");


            
            #line 127 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n");



WriteLiteral("                                    <td class=\"min-width\">\r\n");


            
            #line 130 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                         if (parentStateData != null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <a href=\"");


            
            #line 132 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                Write(Url.JobDetails(stateData.Data["ParentId"]));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                <span class=\"label label-defa" +
"ult label-hover\" style=\"");


            
            #line 133 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                                                                 Write(String.Format("background-color: {0};", JobHistoryRenderer.GetForegroundStateColor(parentStateData.Name)));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                    ");


            
            #line 134 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                               Write(parentStateData.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </span>\r\n                      " +
"                      </a>\r\n");


            
            #line 137 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>N/A</em>\r\n");


            
            #line 141 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n");



WriteLiteral("                                    <td class=\"min-width align-right\">\r\n         " +
"                               ");


            
            #line 144 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                   Write(Html.RelativeTime(jobData.CreatedAt));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n");


            
            #line 146 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tr>\r\n");


            
            #line 148 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n                ");


            
            #line 151 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
           Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 153 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\r\n                No jobs found in awai" +
"ting state.\r\n            </div>\r\n");


            
            #line 159 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
