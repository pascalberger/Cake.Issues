---
title: Cake Issues Markdownlint v1.1.0 Released
date: 2021-08-31
categories:
  - Release Notes
links:
  - documentation/issue-providers/markdownlint/index.md
---

Version 1.1.0 of Markdownlint support for Cake.Issues has been released.
This is a minor release adding features and improvements.

<!-- more -->

This post shows the highlights included in this release.
For update instructions skip to [Updating from previous versions](#updating-from-previous-versions).

❤ Huge thanks to our community! This release would not have been possible without your support and contributions! ❤

People working on this release:

* [pascalberger](https://github.com/pascalberger){target="_blank"}

## Support for markdownlint-cli JSON format

Since version 0.28.0 markdownlint-cli supports a `--json` option to output result in JSON format.
This version adds support for this format through the [MarkdownlintCliJsonLogFileFormat]{target="_blank"} alias.

## Provide column information

This release of Cake.Issues.Markdownlint enhances the [MarkdownlintCliLogFileFormat]{target="_blank"} to provide column information
if reported by markdownlint.

## Recipe packages

[Cake Issues recipes] have been released in version 1.3.0 shipping with Cake.Issues.Markdownlint 1.1.0 and
adding support for markdownlint-cli JSON files.

## Updating from previous versions

Cake.Issues.Markdownlint 1.1.0 is compatible with version 1.0.0 without any breaking changes.
To update to the new version bump the version of the addin.

[MarkdownlintCliJsonLogFileFormat]: https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/36DE6F5F
[MarkdownlintCliLogFileFormat]: https://cakebuild.net/api/Cake.Issues.Markdownlint/MarkdownlintIssuesAliases/B518F49E
[Cake Issues recipes]: ../../documentation/recipe/index.md