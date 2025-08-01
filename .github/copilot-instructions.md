This is a .NET based repository containing addins for the Cake Build Automation System.
The individual addins are published as NuGet packages.
Follow these guidelines when contributing:

## Code Standards
- Roslyn analyzers are used to enforce code quality and style.
- Ensure not warning or error messages are present in the code.

## Development Flow
- Build: `build.sh --target=DotNetCore-Build`
- Publish NuGet Packages: `build.sh --target=Create-NuGet-Packages`
- Test: `build.sh --target=Test`
- Full CI check: `build.sh` (includes build, lint, test)
- Building website: `build.sh --target=website`. Website is available on http://127.0.0.1:8000/

## Repository Structure
- `src`: Contains the source code for the addins
  - Each addin should have its own subdirectory under `src`
  - Use a consistent naming convention for directories and files
- `nuspec/nuget`: Contains the NuGet specification files for each addin
  - Each addin should have its own `.nuspec` file
  - Each addin is published for Cake .NET Tool and Cake Frosting in their separate `.nuspec` files
  - Each package should have a README file in Markdown format
  - Cake Frosting packages should contain a targets file to import the namespace of the addin
- `docs`: Contains documentation for the addins
  - Documentation is created uses Material for MkDocs
  - Use Markdown format for documentation files
  - Include usage examples where applicable
- `tests`: Contains integration tests for the addins
  - Each addin should have its own subdirectory under `tests`
  - Cake .NET Tool tests should be in `tests/<ADDIN-NAME>/script-runner`
  - Cake Frosting tests should be in `tests/<ADDIN-NAME>/frosting`
  - Cake Frosting tests should be available for all supported .NET Framework versions
- `.github/workflows`: Contains GitHub Actions workflows for CI/CD which need to be maintained
- `.azuredevops/pipelines/templates`: Contains Azure Pipelines templates which need to be maintained. The main file is `azure-pipelines.yml` in the root directory.

## Key Guidelines
1. Follow best practices for writing Cake addins as documented at https://cakebuild.net/docs/extending/addins/best-practices
2. For specific issue providers, report formats and pull request systems, refer to the documentation at https://cakeissues.net/latest/documentation/extending/ and sub pages.
3. Maintain existing code structure and organization
4. Write unit tests for new functionality.
  - Use helpers from `src/Cake.Issues.Testing` when writing unit tests.
  - Use `src/Cake.Issues.Testing/IssueChecker.cs` to compare issues against expected results. 
5. Write integration tests for new functionality which can't be tested with unit tests.
6. Maintain basic documentation in the `docs/` folder. Avoid API documentation which is automatically generated.