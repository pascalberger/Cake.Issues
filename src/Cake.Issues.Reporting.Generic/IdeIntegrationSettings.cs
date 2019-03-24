﻿namespace Cake.Issues.Reporting.Generic
{
    /// <summary>
    /// Settings how issues should be integrated to IDEs.
    /// </summary>
    public class IdeIntegrationSettings
    {
        /// <summary>
        /// Gets or sets additional JavaScript which should be added.
        /// </summary>
        public string JavaScript { get; set; }

        /// <summary>
        /// Gets or sets JavaScript which should be called to open the file affected by an issue in an IDE.
        /// </summary>
        public string OpenInIdeCall { get; set; }

        /// <summary>
        /// Gets or sets text which should be shown in the drop down menu for opening the file affected
        /// by an issue in an IDE.
        /// Default value is <c>Open in IDE</c>.
        /// </summary>
        public string MenuEntryText { get; set; } = "Open in IDE";

        /// <summary>
        /// Returns the JavaScript which should be called to open the file affected by an issue in an IDE
        /// with all patterns of <see cref="OpenInIdeCall"/> replaced.
        /// </summary>
        /// <param name="filePathExpression">Expression which should be used to get the path and name
        /// of the file at runtime.</param>
        /// <param name="lineExpression">Expression which should be used to get the line number at runtime.</param>
        /// <returns>JavaScript which should be called to open the file affected by an issue in an IDE
        /// with all patterns replaced.</returns>
        public string GetOpenInIdeCall(string filePathExpression, string lineExpression)
        {
            filePathExpression.NotNullOrWhiteSpace(nameof(filePathExpression));
            lineExpression.NotNullOrWhiteSpace(nameof(lineExpression));

            if (string.IsNullOrWhiteSpace(this.OpenInIdeCall))
            {
                return null;
            }

            return
                this.OpenInIdeCall
                    .Replace("{FilePath}", filePathExpression)
                    .Replace("{Line}", lineExpression);
        }
    }
}
