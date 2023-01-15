namespace OpenAI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using OpenAI;
    using Xunit;

    /// <summary>
    /// This wholesome test ensures that all OpenAI entity and options classes implement the
    /// <c>IHasX</c> interfaces when they have matching properties.
    /// </summary>
    public class DontForgetIHasInterfaces : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one missing interface.";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all classes that derive from OpenAIEntity or implement INestedOptions
            var openAIClasses = GetSubclassesOf(typeof(OpenAIEntity));
            openAIClasses.AddRange(GetClassesWithInterface(typeof(INestedOptions)));

            foreach (Type openAIClass in openAIClasses)
            {
                var interfaces = openAIClass.GetInterfaces();

                foreach (PropertyInfo property in openAIClass.GetProperties())
                {
                    // Check for IHasId
                    if ((property.Name == "Id") && (property.PropertyType == typeof(string)))
                    {
                        if (!interfaces.Contains(typeof(IHasId)))
                        {
                            results.Add($"{openAIClass.Name} is missing IHasId");
                        }
                    }

                    // Check for IHasObject
                    if ((property.Name == "Object") && (property.PropertyType == typeof(string)))
                    {
                        if (!interfaces.Contains(typeof(IHasObject)))
                        {
                            results.Add($"{openAIClass.Name} is missing IHasObject");
                        }
                    }
                }
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
