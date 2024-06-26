﻿namespace Cake.Issues.InspectCode.Tests;

public sealed class ExtensionsTests
{
    public sealed class TheToUriExtension
    {
        [Fact]
        public void Should_Throw_If_Value_Is_Null()
        {
            // Given
            const string value = null;

            // When
            var result = Record.Exception(value.ToUri);

            // Then
            result.IsArgumentNullException("value");
        }

        [Fact]
        public void Should_Throw_If_Value_Is_Empty()
        {
            // Given
            var value = string.Empty;

            // When
            var result = Record.Exception(value.ToUri);

            // Then
            result.IsArgumentOutOfRangeException("value");
        }

        [Fact]
        public void Should_Throw_If_Value_Is_WhiteSpace()
        {
            // Given
            const string value = " ";

            // When
            var result = Record.Exception(value.ToUri);

            // Then
            result.IsArgumentOutOfRangeException("value");
        }

        [Fact]
        public void Should_Return_Uri()
        {
            // Given
            const string value = "https://google.com/";

            // When
            var result = value.ToUri();

            // Then
            result.ToString().ShouldBe(value);
        }
    }
}
