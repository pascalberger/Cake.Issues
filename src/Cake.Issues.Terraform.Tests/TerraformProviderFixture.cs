﻿namespace Cake.Issues.Terraform.Tests;

using Cake.Core.IO;

internal class TerraformProviderFixture : BaseConfigurableIssueProviderFixture<TerraformIssuesProvider, TerraformIssuesSettings>
{
    private readonly DirectoryPath docRootPath;

    public TerraformProviderFixture(string fileResourceName, DirectoryPath docRootPath)
        : base(fileResourceName)
    {
        docRootPath.NotNull();

        this.docRootPath = docRootPath;
        this.ReadIssuesSettings =
            new ReadIssuesSettings(@"c:\Source\Cake.Issues");
    }

    protected override string FileResourceNamespace => "Cake.Issues.Terraform.Tests.Testfiles.";

    protected override IList<object> GetCreateIssueProviderSettingsArguments()
    {
        var result = base.GetCreateIssueProviderSettingsArguments();
        result.Add(this.docRootPath);
        return result;
    }
}
