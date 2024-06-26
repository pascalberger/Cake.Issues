﻿namespace Cake.Issues.InspectCode;

using System;

/// <summary>
/// Class containing extensions.
/// </summary>
internal static class Extensions
{
    /// <summary>
    /// Returns an <see cref="Uri"/> for a URL string.
    /// </summary>
    /// <param name="value">URL to convert.</param>
    /// <returns><see cref="Uri"/> created from <paramref name="value"/>.</returns>
    public static Uri ToUri(this string value)
    {
        value.NotNullOrWhiteSpace();

        return new Uri(value);
    }
}
