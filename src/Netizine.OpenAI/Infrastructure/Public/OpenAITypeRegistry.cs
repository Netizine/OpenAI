// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;

    /// <summary>
    /// The OpenAI type registry.
    /// </summary>
    public static class OpenAITypeRegistry
    {
        /// <summary>
        /// Dictionary mapping the values contained in the `object` key of JSON payloads returned
        /// by OpenAI's API to concrete types of model classes.
        /// </summary>
        public static readonly IReadOnlyDictionary<string, Type> ObjectsToTypes = new ReadOnlyDictionary<string, Type>(
            new Dictionary<string, Type>
            {
#pragma warning disable CS0618
                { "engine", typeof(Engine) },
#pragma warning restore CS0618
                { "model", typeof(Model) },
                { "completion", typeof(Completion) },
                { "chatCompletion", typeof(ChatCompletion) },
                { "edit", typeof(Edit) },
                { "image", typeof(Image) },
                { "embedding", typeof(Embedding) },
                { "file", typeof(File) },
                { "file-content", typeof(FileContent) },
                { "fine-tune", typeof(FineTune) },
                { "fine-tune-event", typeof(FineTuneEvents) },
                { "moderation", typeof(Moderation) },
            });

        /// <summary>
        /// Returns the concrete type to use, given a potential type and the value of the `object`
        /// key in a JSON payload.
        /// </summary>
        /// <param name="potentialType">Potential type. Can be a concrete type or an interface.</param>
        /// <param name="objectValue">Value of the `object` key in the JSON payload.</param>
        /// <returns>The concrete type to use, or `null`.</returns>
        public static Type GetConcreteType(Type potentialType, string objectValue)
        {
            if (potentialType != null && !potentialType.GetTypeInfo().IsInterface)
            {
                // Potential type is already a concrete type, return it.
                return potentialType;
            }

            if (string.IsNullOrEmpty(objectValue) ||
                !ObjectsToTypes.TryGetValue(objectValue, out var concreteType))
            {
                return null;
            }
            // Found a concrete type matching the value of the `object` key, check if it's
            // compatible with the interface.
            if (potentialType != null && potentialType.GetTypeInfo().IsAssignableFrom(concreteType.GetTypeInfo()))
            {
                return concreteType;
            }

            return null;
        }
    }
}