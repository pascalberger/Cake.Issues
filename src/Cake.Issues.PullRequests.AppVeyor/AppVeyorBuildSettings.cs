﻿namespace Cake.Issues.PullRequests.AppVeyor;

/// <summary>
/// Settings for <see cref="AppVeyorBuildsAliases"/>.
/// </summary>
public class AppVeyorBuildSettings
{
    private string messagePattern = "Project: {ProjectName}, File: {FilePath}, Line: {Line}";
    private string detailsPattern = "{Rule}: {MessageText}";

    /// <summary>
    /// Initializes a new instance of the <see cref="AppVeyorBuildSettings"/> class.
    /// </summary>
    public AppVeyorBuildSettings()
    {
    }

    /// <summary>
    /// Gets or sets the pattern of the message to display.
    /// See <see cref="Cake.Issues.IIssueExtensions.ReplaceIssuePattern(string, IIssue)"/> for possible patterns.
    /// The default value is: "Project: {ProjectName}, File: {FilePath}, Line: {Line}".
    /// </summary>
    public string MessagePattern
    {
        get => this.messagePattern;
        set
        {
            value.NotNull();
            this.messagePattern = value;
        }
    }

    /// <summary>
    /// Gets or sets the pattern of the message details to display.
    /// See <see cref="Cake.Issues.IIssueExtensions.ReplaceIssuePattern(string, IIssue)"/> for possible patterns.
    /// The default value is: "{Rule}: {MessageText}".
    /// </summary>
    public string DetailsPattern
    {
        get => this.detailsPattern;
        set
        {
            value.NotNull();
            this.detailsPattern = value;
        }
    }
}