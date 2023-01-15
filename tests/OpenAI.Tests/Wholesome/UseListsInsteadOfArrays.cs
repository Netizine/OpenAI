namespace OpenAI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that lists (as in <see cref="List{T}"/>) are used instead of
    /// arrays (<c>[]</c>) in OpenAI entities and options classes.
    /// </summary>
    public class UseListsInsteadOfArrays : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one array type. Please use List<> instead.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from OpenAIEntity or implement INestedOptions
            var openAIClasses = GetSubclassesOf(typeof(OpenAIEntity));
            openAIClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (Type openAIClass in openAIClasses)
            {
                foreach (PropertyInfo property in openAIClass.GetProperties())
                {
                    var propType = property.PropertyType;

                    // Skip properties that don't have a `JsonProperty` attribute
                    var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                    if (attribute == null)
                    {
                        continue;
                    }

                    // Skip non-array types
                    if (!propType.GetTypeInfo().IsArray)
                    {
                        continue;
                    }

                    //Skip image and mask
                    if (property.Name == "Image" || property.Name == "Mask")
                    {
                        continue;
                    }

                    results.Add($"{openAIClass.Name}.{property.Name}");
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
