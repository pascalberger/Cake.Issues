﻿namespace Cake.Issues
{
    /// <summary>
    /// Extensions for <see cref="IIssue"/>.
    /// </summary>
    public static class IIssueExtensions
    {
        /// <summary>
        /// Returns the full path of <see cref="IIssue.ProjectFileRelativePath"/> or <c>null</c>.
        /// </summary>
        /// <param name="issue">Issue for which the path should be returned.</param>
        /// <returns>Full path to the project to which the file affected by the issue belongs.</returns>
        public static string ProjectPath(this IIssue issue)
        {
            issue.NotNull(nameof(issue));

            return issue.ProjectFileRelativePath?.FullPath;
        }

        /// <summary>
        /// Returns the directory of the <see cref="IIssue.ProjectFileRelativePath"/>.
        /// </summary>
        /// <param name="issue">Issue for which the project directory should be returned.</param>
        /// <returns>Directory of the project to which the file affected by the issue belongs.</returns>
        public static string ProjectDirectory(this IIssue issue)
        {
            issue.NotNull(nameof(issue));

            return issue.ProjectFileRelativePath?.GetDirectory().FullPath;
        }

        /// <summary>
        /// Returns the full path of the <see cref="IIssue.AffectedFileRelativePath"/>.
        /// </summary>
        /// <param name="issue">Issue for which the path should be returned.</param>
        /// <returns>Full path of the file affected by the issue.</returns>
        public static string FilePath(this IIssue issue)
        {
            issue.NotNull(nameof(issue));

            return issue.AffectedFileRelativePath?.FullPath;
        }

        /// <summary>
        /// Returns the directory of the <see cref="IIssue.AffectedFileRelativePath"/>.
        /// </summary>
        /// <param name="issue">Issue for which the directory should be returned.</param>
        /// <returns>Directory of the file affected by the issue.</returns>
        public static string FileDirectory(this IIssue issue)
        {
            issue.NotNull(nameof(issue));

            return issue.AffectedFileRelativePath?.GetDirectory().FullPath;
        }

        /// <summary>
        /// Returns the name of the file of the <see cref="IIssue.AffectedFileRelativePath"/>.
        /// </summary>
        /// <param name="issue">Issue for which the file name should be returned.</param>
        /// <returns>Name of the file affected by the issue.</returns>
        public static string FileName(this IIssue issue)
        {
            issue.NotNull(nameof(issue));

            return issue.AffectedFileRelativePath?.GetFilename().ToString();
        }
    }
}