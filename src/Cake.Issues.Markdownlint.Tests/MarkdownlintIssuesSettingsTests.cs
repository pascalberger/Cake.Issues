﻿namespace Cake.Issues.Markdownlint.Tests;

using Cake.Core.IO;
using Cake.Issues.Markdownlint;
using Cake.Issues.Markdownlint.LogFileFormat;

public sealed class MarkdownlintIssuesSettingsTests
{
    public sealed class TheCtor
    {
        [Fact]
        public void Should_Throw_If_LogFilePath_Is_Null()
        {
            // Given
            FilePath logFilePath = null;
            var format = new MarkdownlintV1LogFileFormat(new FakeLog());

            // When
            var result = Record.Exception(() =>
                new MarkdownlintIssuesSettings(logFilePath, format));

            // Then
            result.IsArgumentNullException("logFilePath");
        }

        [Fact]
        public void Should_Throw_If_Format_For_LogFilePath_Is_Null()
        {
            // Given
            BaseMarkdownlintLogFileFormat format = null;

            using (var tempFile = new ResourceTempFile("Cake.Issues.Markdownlint.Tests.Testfiles.MarkdownlintV1LogFileFormat.markdownlint.json"))
            {
                // When
                var result = Record.Exception(() =>
                    new MarkdownlintIssuesSettings(tempFile.FileName, format));

                // Then
                result.IsArgumentNullException("format");
            }
        }

        [Fact]
        public void Should_Throw_If_LogFileContent_Is_Null()
        {
            // Given
            byte[] logFileContent = null;
            var format = new MarkdownlintV1LogFileFormat(new FakeLog());

            // When
            var result = Record.Exception(() =>
                new MarkdownlintIssuesSettings(logFileContent, format));

            // Then
            result.IsArgumentNullException("logFileContent");
        }

        [Fact]
        public void Should_Throw_If_Format_For_LogFileContent_Is_Null()
        {
            // Given
            var logFileContent = "foo".ToByteArray();
            BaseMarkdownlintLogFileFormat format = null;

            // When
            var result = Record.Exception(() =>
                new MarkdownlintIssuesSettings(logFileContent, format));

            // Then
            result.IsArgumentNullException("format");
        }

        [Fact]
        public void Should_Set_LogFileContent()
        {
            // Given
            var logFileContent = "Foo".ToByteArray();
            var format = new MarkdownlintV1LogFileFormat(new FakeLog());

            // When
            var settings = new MarkdownlintIssuesSettings(logFileContent, format);

            // Then
            settings.LogFileContent.ShouldBe(logFileContent);
        }

        [Fact]
        public void Should_Set_LogFileContent_If_Empty()
        {
            // Given
            byte[] logFileContent = [];
            var format = new MarkdownlintV1LogFileFormat(new FakeLog());

            // When
            var settings = new MarkdownlintIssuesSettings(logFileContent, format);

            // Then
            settings.LogFileContent.ShouldBe(logFileContent);
        }

        [Fact]
        public void Should_Set_LogFileContent_From_LogFilePath()
        {
            // Given
            var format = new MarkdownlintV1LogFileFormat(new FakeLog());
            using (var tempFile = new ResourceTempFile("Cake.Issues.Markdownlint.Tests.Testfiles.MarkdownlintV1LogFileFormat.markdownlint.json"))
            {
                // When
                var settings = new MarkdownlintIssuesSettings(tempFile.FileName, format);

                // Then
                settings.LogFileContent.ShouldBe(tempFile.Content);
            }
        }
    }
}
