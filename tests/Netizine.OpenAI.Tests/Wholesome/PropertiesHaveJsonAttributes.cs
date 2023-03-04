namespace OpenAI.Tests
{
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that all properties in OpenAI entities and options classes are
    /// annotated with either <see cref="JsonPropertyAttribute"/> or
    /// <see cref="JsonIgnoreAttribute"/>.
    /// </summary>
    public class PropertiesHaveJsonAttributes : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one property lacking a Json*Attribute. Please add either a "
            + "[JsonProperty(\"name\")] or a [JsonIgnore] attribute.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from OpenAIEntity or implement INestedOptions
            var openAIClasses = GetSubclassesOf(typeof(OpenAIEntity));
            openAIClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (var openAIClass in openAIClasses)
            {
                foreach (var property in openAIClass.GetProperties())
                {
                    var hasJsonAttribute = false;

                    foreach (var attribute in property.GetCustomAttributes())
                    {
                        if (attribute.GetType() == typeof(JsonPropertyAttribute)
                            || attribute.GetType() == typeof(JsonIgnoreAttribute)
                            || attribute.GetType() == typeof(JsonExtensionDataAttribute))
                        {
                            hasJsonAttribute = true;
                            break;
                        }
                    }

                    if (hasJsonAttribute)
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
