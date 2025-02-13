---
title: Features
description: Features of the Cake.Issues.Markdownlint addin.
icon: material/creation-outline
---

The [Cake.Issues.Markdownlint addin](https://cakebuild.net/extensions/cake-issues-markdownlint/){target="_blank"}
provides the following features.

??? tip "Tip: Running markdownlint"
    [markdownlint-cli](https://github.com/igorshubovych/markdownlint-cli){target="_blank"}
    can be run with the [Cake.Markdownlint](https://cakebuild.net/extensions/cake-markdownlint/){target="_blank"}
    addin.

## Basic features

- [x] Reads warnings from [Markdownlint](https://github.com/DavidAnson/markdownlint){target="_blank"} logfiles.
- [x] Provides URLs for all issues.
- [x] Support for custom URL resolving using the [MarkdownlintAddRuleUrlResolver](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/2EE35F55){target="_blank"}
  alias (except for [MarkdownlintCliJsonLogFileFormat](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/36DE6F5F){target="_blank"}).

## Supported log file formats

- [x] [MarkdownlintV1LogFileFormat](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/65609BEB){target="_blank"}
  alias for reading issues from [Markdownlint](https://github.com/DavidAnson/markdownlint){target="_blank"}
  output generated with `options.resultVersion` set to 1.
- [x] [MarkdownlintCliLogFileFormat](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/B518F49E){target="_blank"}
  alias for reading issues from [markdownlint-cli](https://github.com/igorshubovych/markdownlint-cli){target="_blank"} log files.
- [x] [MarkdownlintCliJsonLogFileFormat](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/36DE6F5F){target="_blank"}
  alias for reading issues from [markdownlint-cli](https://github.com/igorshubovych/markdownlint-cli){target="_blank"}
  log files created with the `--json` parameter.

## Supported IIssue properties

=== "MarkdownlintV1LogFileFormat"

    <div class="annotate" markdown>
    
    - [x] `IIssue.ProviderType`
    - [x] `IIssue.ProviderName`
    - [ ] `IIssue.Run` (1)
    - [x] `IIssue.Identifier` (2)
    - [ ] `IIssue.ProjectName`
    - [ ] `IIssue.ProjectFileRelativePath`
    - [x] `IIssue.AffectedFileRelativePath`
    - [x] `IIssue.Line`
    - [ ] `IIssue.EndLine`
    - [ ] `IIssue.Column` 
    - [ ] `IIssue.EndColumn`
    - [ ] `IIssue.FileLink` (3)
    - [x] `IIssue.MessageText`
    - [ ] `IIssue.MessageHtml`
    - [ ] `IIssue.MessageMarkdown`
    - [x] `IIssue.Priority` (4)
    - [x] `IIssue.PriorityName` (5)
    - [x] `IIssue.RuleId`
    - [x] `IIssue.RuleUrl` (6)
    
    </div>
    
    1.  Can be set while reading issues
    2.  Set to `IIssue.MessageText`
    3.  Can be set while reading issues
    4.  Always [IssuePriority.Warning](https://cakebuild.net/api/Cake.Issues/IssuePriority/7A0CE07F){target="_blank"}
    5.  Always `Warning`
    6.  Support for custom rules can be added through a custom [MarkdownlintAddRuleUrlResolver](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/2EE35F55){target="_blank"}

=== "MarkdownlintCliLogFileFormat"

    <div class="annotate" markdown>
    
    - [x] `IIssue.ProviderType`
    - [x] `IIssue.ProviderName`
    - [ ] `IIssue.Run` (1)
    - [x] `IIssue.Identifier` (2)
    - [ ] `IIssue.ProjectName`
    - [ ] `IIssue.ProjectFileRelativePath`
    - [x] `IIssue.AffectedFileRelativePath`
    - [x] `IIssue.Line`
    - [ ] `IIssue.EndLine`
    - [x] `IIssue.Column`
    - [ ] `IIssue.EndColumn`
    - [ ] `IIssue.FileLink` (3)
    - [x] `IIssue.MessageText`
    - [ ] `IIssue.MessageHtml`
    - [ ] `IIssue.MessageMarkdown`
    - [x] `IIssue.Priority` (4)
    - [x] `IIssue.PriorityName` (5)
    - [x] `IIssue.RuleId`
    - [x] `IIssue.RuleUrl` (6)
    
    </div>
    
    1.  Can be set while reading issues
    2.  Set to `IIssue.MessageText`
    3.  Can be set while reading issues
    4.  Always [IssuePriority.Warning](https://cakebuild.net/api/Cake.Issues/IssuePriority/7A0CE07F){target="_blank"}
    5.  Always `Warning`
    6.  Support for custom rules can be added through a custom [MarkdownlintAddRuleUrlResolver](https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/2EE35F55){target="_blank"}

=== "MarkdownlintCliJsonLogFileFormat"

    <div class="annotate" markdown>
    
    - [x] `IIssue.ProviderType`
    - [x] `IIssue.ProviderName`
    - [ ] `IIssue.Run` (1)
    - [x] `IIssue.Identifier` (2)
    - [ ] `IIssue.ProjectName`
    - [ ] `IIssue.ProjectFileRelativePath`
    - [x] `IIssue.AffectedFileRelativePath`
    - [x] `IIssue.Line`
    - [x] `IIssue.EndLine`
    - [x] `IIssue.Column`
    - [x] `IIssue.EndColumn`
    - [ ] `IIssue.FileLink` (3)
    - [x] `IIssue.MessageText`
    - [ ] `IIssue.MessageHtml`
    - [ ] `IIssue.MessageMarkdown`
    - [x] `IIssue.Priority` (4)
    - [x] `IIssue.PriorityName` (5)
    - [x] `IIssue.RuleId`
    - [x] `IIssue.RuleUrl`
    
    </div>
    
    1.  Can be set while reading issues
    2.  Set to `IIssue.MessageText`
    3.  Can be set while reading issues
    4.  Always [IssuePriority.Warning](https://cakebuild.net/api/Cake.Issues/IssuePriority/7A0CE07F){target="_blank"}
    5.  Always `Warning`
