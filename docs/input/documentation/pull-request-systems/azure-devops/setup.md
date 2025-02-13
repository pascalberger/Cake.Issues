---
title: Setup
description: Instructions how to setup the Cake.Issues.PullRequests.AzureDevOps addin.
icon: material/cogs
---

This page describes the different ways how the [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} can be setup.

## NTLM authentication

!!! info
    NTLM authentication is only available for on-premise Azure DevOps Server.

To authenticate with NTLM you can use the [AzureDevOpsAuthenticationNtlm]{target="_blank"} alias from the [Cake.AzureDevOps addin]{target="_blank"}.

The user needs to have `Contribute to pull requests` permission for the specific repository to
allow [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} to post issues as comments to pull requests.

## Basic authentication

!!! info
    Basic authentication is only available for on-premise Azure DevOps Server.

To authenticate with basic authentication you can use the [AzureDevOpsAuthenticationBasic]{target="_blank"} alias from the [Cake.AzureDevOps addin]{target="_blank"} and
need to [Configure Azure DevOps Server to use Basic Authentication]{target="_blank"}.

The user needs to have `Contribute to pull requests` permission for the specific repository to
allow [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} to post issues as comments to pull requests.

## Personal access token

To authenticate with an personal access token you can use the [AzureDevOpsAuthenticationPersonalAccessToken]{target="_blank"} alias from the [Cake.AzureDevOps addin]{target="_blank"}.

If you want to use the [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} with an personal access token see
[Authenticate access with personal access tokens for Azure DevOps]{target="_blank"} for instructions how to create
a personal access token.

The access token needs to have the scope `Code (read and write)` set and the user needs to have `Contribute to pull requests`
permission for the specific repository to allow [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} to post issues as comments to pull requests.

## OAuth authentication from Azure Pipelines

!!! info
    OAuth authentication is only available for Azure DevOps Service.

If you want to use the [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} from an Azure Pipelines you can authenticate using the
OAuth token provided to the build.
For this you need to enable the [Allow scripts to access the OAuth token]{target="_blank"} option on the build definition.

To authenticate you can use the [AzureDevOpsAuthenticationOAuth]{target="_blank"} alias from the [Cake.AzureDevOps addin]{target="_blank"}.

The user under which the build runs, named `<projectName> Build Service (<organizationName>)` (e.g. `Cake.Issues-Demo Build Service (cake-contrib)`),
needs to have `Contribute to pull requests` permission for the specific repository to allow [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"}
to post issues as comments to pull requests.

## Entra authentication

!!! info
    Entra authentication is only available for Azure DevOps Service.

To authenticate with Entra ID you can use the [AzureDevOpsAuthenticationAzureActiveDirectory]{target="_blank"} alias from the [Cake.AzureDevOps addin]{target="_blank"}.

The user needs to have `Contribute to pull requests` permission for the specific repository to
allow [Cake.Issues.PullRequests.AzureDevOps addin]{target="_blank"} to post issues as comments to pull requests.

[Cake.Issues.PullRequests.AzureDevOps addin]: https://cakebuild.net/extensions/cake-issues-pullrequests-azuredevops/
[Cake.AzureDevOps addin]: https://cakebuild.net/extensions/cake-azuredevops/
[Configure Azure DevOps Server to use Basic Authentication]: https://learn.microsoft.com/en-us/azure/devops/integrate/get-started/auth/tfs-basic-auth#configure-for-basic-authentication
[Authenticate access with personal access tokens for Azure DevOps]: https://learn.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate
[Allow scripts to access the OAuth token]: https://learn.microsoft.com/en-us/azure/devops/pipelines/release/options?view=azure-devops#allow-scripts-to-access-the-oauth-token
[AzureDevOpsAuthenticationNtlm]: https://cakebuild.net/api/Cake.AzureDevOps/AzureDevOpsAliases/F2A040B7
[AzureDevOpsAuthenticationBasic]: https://cakebuild.net/api/Cake.AzureDevOps/AzureDevOpsAliases/7CD679FF
[AzureDevOpsAuthenticationPersonalAccessToken]: https://cakebuild.net/api/Cake.AzureDevOps/AzureDevOpsAliases/F4DCC101
[AzureDevOpsAuthenticationOAuth]: https://cakebuild.net/api/Cake.AzureDevOps/AzureDevOpsAliases/988E9C28
[AzureDevOpsAuthenticationAzureActiveDirectory]: https://cakebuild.net/api/Cake.AzureDevOps/AzureDevOpsAliases/0B9F5DF6
