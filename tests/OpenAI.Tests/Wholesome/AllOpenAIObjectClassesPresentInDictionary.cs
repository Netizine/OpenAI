namespace OpenAI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenAI;
    using Xunit;

    /// <summary>
    /// This test checks that all OpenAI object classes (i.e. model classes that implement
    /// <see cref="OpenAI.IHasObject" />) have an entry in the
    /// <see cref="OpenAITypeRegistry.ObjectsToTypes" /> dictionary.
    /// </summary>
    public class AllOpenAIObjectClassesPresentInDictionary : WholesomeTest
    {
        private const string AssertionMessage =
            "Found at least one model class missing in ObjectsToTypes dictionary";

        [Fact]
        public void Check()
        {
            List<string> results = new List<string>();

            // Get all OpenAIEntity subclasses that implement IHasObject
            var modelClasses = GetSubclassesOf(typeof(OpenAIEntity))
                .Intersect(GetClassesWithInterface(typeof(IHasObject)));

            foreach (Type modelClass in modelClasses)
            {
                // Skip types present in dictionary
                if (OpenAITypeRegistry.ObjectsToTypes.Any(kv => kv.Value == modelClass))
                {
                    continue;
                }

                // OpenAIList is a generic type that is handled separately
                if (modelClass == typeof(OpenAIList<>))
                {
                    continue;
                }

                results.Add(modelClass.Name);
            }

            AssertEmpty(results, AssertionMessage);
        }
    }
}
