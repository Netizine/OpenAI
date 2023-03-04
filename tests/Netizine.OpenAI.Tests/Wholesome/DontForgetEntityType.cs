namespace OpenAI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using OpenAI;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that all OpenAI entity and options classes implement the
    /// <c>IHasX</c> interfaces when they have matching properties.
    /// </summary>
    public class DontForgetEntityType : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one class with an incorrect base type.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from OpenAIEntity
            var openAIClasses = GetSubclassesOf(typeof(OpenAIEntity));

            foreach (Type openAIClass in openAIClasses)
            {
                var baseType = openAIClass.GetTypeInfo().BaseType;

                // Skip the generic version of OpenAIEntity
                if (openAIClass == typeof(OpenAIEntity<>))
                {
                    continue;
                }

                if (!baseType.GetTypeInfo().IsGenericType ||
                    baseType.GetGenericTypeDefinition() != typeof(OpenAIEntity<>))
                {
                    results.Add($"{openAIClass.Name} inherits from {baseType.Name} instead of OpenAIEntity<{openAIClass.Name}>");
                    continue;
                }

                var typeParam = baseType.GetTypeInfo().GetGenericArguments()[0];
                if (typeParam != openAIClass)
                {
                    results.Add($"{openAIClass.Name} inherits from OpenAIEntity<{typeParam.Name}> instead of OpenAIEntity<{openAIClass.Name}>");
                    continue;
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
