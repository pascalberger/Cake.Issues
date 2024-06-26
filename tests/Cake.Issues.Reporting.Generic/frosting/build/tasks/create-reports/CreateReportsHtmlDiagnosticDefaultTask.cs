using Cake.Frosting;

[TaskName("Create-Reports-HtmlDiagnostic-Default")]
[IsDependentOn(typeof(AnalyzeTask))]
public class CreateReportsHtmlDiagnosticDefaultTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        context.CreateIssueReport(
            context.Issues,
            context.GenericIssueReportFormatFromEmbeddedTemplate(GenericIssueReportTemplate.HtmlDiagnostic),
            context.RepoRootFolder,
            context.TemplateGalleryFolder.CombineWithFilePath("htmldiagnostic-demo-default.html"));

    }
}