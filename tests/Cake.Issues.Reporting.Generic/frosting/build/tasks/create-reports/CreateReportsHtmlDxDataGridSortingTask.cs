using Cake.Frosting;

[TaskName("Create-Reports-HtmlDxDataGrid-Sorting")]
[IsDependentOn(typeof(AnalyzeTask))]
public class CreateReportsHtmlDxDataGridSortingTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CreateIssueReport(
            context.Issues,
            context.GenericIssueReportFormatFromEmbeddedTemplate(
                GenericIssueReportTemplate.HtmlDxDataGrid,
                settings =>
                    settings
                        .WithOption(HtmlDxDataGridOption.SortedColumns, new List<ReportColumn> { ReportColumn.RuleId })
                        .WithOption(HtmlDxDataGridOption.RuleIdSortOrder, ColumnSortOrder.Descending)),
            context.RepoRootFolder,
            context.TemplateGalleryFolder.CombineWithFilePath("htmldxdatagrid-demo-sorting.html"));

    }
}