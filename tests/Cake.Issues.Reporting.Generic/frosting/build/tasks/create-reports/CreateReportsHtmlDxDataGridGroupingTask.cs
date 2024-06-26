using Cake.Frosting;

[TaskName("Create-Reports-HtmlDxDataGrid-Grouping")]
[IsDependentOn(typeof(AnalyzeTask))]
public class CreateReportsHtmlDxDataGridGroupingTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CreateIssueReport(
            context.Issues,
            context.GenericIssueReportFormatFromEmbeddedTemplate(
                GenericIssueReportTemplate.HtmlDxDataGrid,
                settings =>
                    settings
                        .WithOption(HtmlDxDataGridOption.GroupedColumns, new List<ReportColumn> { ReportColumn.RuleId })),
            context.RepoRootFolder,
            context.TemplateGalleryFolder.CombineWithFilePath("htmldxdatagrid-demo-grouping.html"));

    }
}