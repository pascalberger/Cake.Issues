---
title: Introduction
description: Introduction
---

Do you want to break your build on JetBrains InspectCode issues?
Do you want to create nice reports for StyleCop issues in your code?
Do you want to have ESLint issues reported as comments to pull requests?
The Cake.Issues addins allows you to do this and much more.
Read issues from different analyzer or linters, create reports or add them as comments to pull requests.

While some linting tools provide nice reporting capabilities, others don't.
Some build systems provide tasks to report issues into pull requests.
But if you're using another build system your out of luck.
Maybe you found a new nice linting tool which does exactly what you need,
but probably it won't integrate well with your existing other linting tools.

The Cake.Issues addins tries to solve this, by providing a common and extensible infrastructure
for issue management in Cake build scripts.

Unlike other Cake addins, the Cake Issues addin consists of over 15 different addins,
working together and providing over 75 aliases which can be used in Cake build scripts to work with issues.
The addins are built in a [modular architecture] and are providing different [extension points] which allows to easily
enhance them for supporting additional analyzers, linters, report formats and code review systems.

!!! tip
    To get started you can use one of the [Cake.Issues recipes], which bring support for different linters and
    integration with build and pull request systems out-of-the box in a single and easy to use NuGet package.

[:fontawesome-solid-video: Presentation](https://gitpitch.com/pascalberger/Cake.Issues-Presentation){ .md-button }

[:fontawesome-solid-graduation-cap: Tutorials](../usage/index.md){ .md-button }

[modular architecture]: ../fundamentals/architecture.md
[extension points]: ../extending/index.md
[Cake.Issues recipes]: ../recipe/overview.md
