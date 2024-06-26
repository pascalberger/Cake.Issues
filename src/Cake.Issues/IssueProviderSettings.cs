﻿namespace Cake.Issues;

using System.IO;
using Cake.Core.IO;

/// <summary>
/// Base settings for an <see cref="BaseConfigurableIssueProvider{T}"/>.
/// </summary>
public class IssueProviderSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueProviderSettings"/> class
    /// for reading a log file on disk.
    /// </summary>
    /// <param name="logFilePath">Path to the log file.</param>
    public IssueProviderSettings(FilePath logFilePath)
    {
        logFilePath.NotNull();

        this.LogFileContent = File.ReadAllBytes(logFilePath.FullPath);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueProviderSettings"/> class
    /// for a log file content in memory.
    /// </summary>
    /// <param name="logFileContent">Content of the log file.</param>
    public IssueProviderSettings(byte[] logFileContent)
    {
        logFileContent.NotNull();

        this.LogFileContent = logFileContent;
    }

    /// <summary>
    /// Gets the content of the log file.
    /// </summary>
    public byte[] LogFileContent { get; }
}
