﻿namespace Cake.Issues.Reporting.Generic.Tests;

using System.Dynamic;

public sealed class ExpandoObjectExtensionsTests
{
    public sealed class TheSerializeToJsonStringExtensionForAnObject
    {
        [Fact]
        public void Should_Throw_If_Object_Is_Null()
        {
            // Given
            ExpandoObject expandoObject = null;

            // When
            var result = Record.Exception(expandoObject.SerializeToJsonString);

            // Then
            result.IsArgumentNullException("expandoObject");
        }

        [Fact]
        public void Should_Give_Correct_Result()
        {
            // Given
            var issue =
                IssueBuilder
                    .NewIssue("message", "providerType", "providerName")
                    .Create();
            var expandoObject =
                issue.GetExpandoObject();

            // When
            var result = expandoObject.SerializeToJsonString();

            // Then
            result.ShouldBe(/*lang=json,strict*/ "{\"ProviderType\":\"providerType\",\"ProviderName\":\"providerName\",\"Run\":null,\"Priority\":null,\"PriorityName\":null,\"ProjectPath\":null,\"ProjectName\":null,\"FilePath\":null,\"FileDirectory\":null,\"FileName\":null,\"FileLink\":null,\"Line\":null,\"EndLine\":null,\"Column\":null,\"EndColumn\":null,\"Location\":\"\",\"RuleId\":null,\"RuleName\":null,\"RuleUrl\":null,\"MessageText\":\"message\"}");
        }
    }

    public sealed class TheSerializeToJsonStringExtensionForAnEnumerable
    {
        [Fact]
        public void Should_Throw_If_Object_Is_Null()
        {
            // Given
            IEnumerable<ExpandoObject> expandoObjects = null;

            // When
            var result = Record.Exception(expandoObjects.SerializeToJsonString);

            // Then
            result.IsArgumentNullException("expandoObjects");
        }

        [Fact]
        public void Should_Give_Correct_Result()
        {
            // Given
            var issue1 =
                IssueBuilder
                    .NewIssue("message1", "providerType1", "providerName1")
                    .Create()
                    .GetExpandoObject();
            var issue2 =
                IssueBuilder
                    .NewIssue("message1", "providerType1", "providerName1")
                    .Create()
                    .GetExpandoObject();
            var expandoObjects =
                new List<ExpandoObject> { issue1, issue2 };

            // When
            var result = expandoObjects.SerializeToJsonString();

            // Then
            result.ShouldBe(/*lang=json,strict*/ "[{\"ProviderType\":\"providerType1\",\"ProviderName\":\"providerName1\",\"Run\":null,\"Priority\":null,\"PriorityName\":null,\"ProjectPath\":null,\"ProjectName\":null,\"FilePath\":null,\"FileDirectory\":null,\"FileName\":null,\"FileLink\":null,\"Line\":null,\"EndLine\":null,\"Column\":null,\"EndColumn\":null,\"Location\":\"\",\"RuleId\":null,\"RuleName\":null,\"RuleUrl\":null,\"MessageText\":\"message1\"},{\"ProviderType\":\"providerType1\",\"ProviderName\":\"providerName1\",\"Run\":null,\"Priority\":null,\"PriorityName\":null,\"ProjectPath\":null,\"ProjectName\":null,\"FilePath\":null,\"FileDirectory\":null,\"FileName\":null,\"FileLink\":null,\"Line\":null,\"EndLine\":null,\"Column\":null,\"EndColumn\":null,\"Location\":\"\",\"RuleId\":null,\"RuleName\":null,\"RuleUrl\":null,\"MessageText\":\"message1\"}]");
        }
    }
}
