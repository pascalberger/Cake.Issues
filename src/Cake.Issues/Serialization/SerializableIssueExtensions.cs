﻿namespace Cake.Issues.Serialization
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extensions for <see cref="SerializableIssue"/>.
    /// </summary>
    internal static class SerializableIssueExtensions
    {
        /// <summary>
        /// Converts a <see cref="SerializableIssue"/> to an <see cref="Issue"/>.
        /// </summary>
        /// <param name="serializableIssue">Issue which should be converted.</param>
        /// <returns>Converted issue.</returns>
        internal static Issue ToIssue(this SerializableIssue serializableIssue)
        {
#pragma warning disable SA1123 // Do not place regions within elements
            #region DupFinder Exclusion
#pragma warning restore SA1123 // Do not place regions within elements

            serializableIssue.NotNull(nameof(serializableIssue));

            Uri ruleUrl = null;
            if (!string.IsNullOrWhiteSpace(serializableIssue.RuleUrl))
            {
                ruleUrl = new Uri(serializableIssue.RuleUrl);
            }

            return new Issue(
                serializableIssue.Message,
                serializableIssue.ProjectFileRelativePath,
                serializableIssue.ProjectName,
                serializableIssue.AffectedFileRelativePath,
                serializableIssue.Line,
                null,
                null,
                null,
                null,
                serializableIssue.Message,
                null,
                null,
                serializableIssue.Priority,
                serializableIssue.PriorityName,
                serializableIssue.Rule,
                ruleUrl,
                null,
                serializableIssue.ProviderType,
                serializableIssue.ProviderName,
                new Dictionary<string, string>());

            #endregion
        }
    }
}
