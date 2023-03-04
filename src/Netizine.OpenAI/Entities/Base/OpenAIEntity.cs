// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Infrastructure;

    /// <summary>
    /// OpenAI Entity.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(OpenAIEntityConverter))]
    public abstract class OpenAIEntity : IOpenAIEntity
    {
        /// <summary>
        /// Gets the raw <see cref="JObject">JObject</see> exposed by the Newtonsoft.Json library.
        /// This can be used to access properties that are not directly exposed by OpenAI's .NET
        /// library.
        /// </summary>
        /// <remarks>
        /// You should always prefer using the standard property accessors whenever possible. This
        /// accessor is not considered fully stable and might change or be removed in future
        /// versions.
        /// </remarks>
        /// <returns>The raw <see cref="JObject">JObject</see>.</returns>
        [JsonIgnore]
        public JObject RawJObject { get; protected set; }

        /// <summary>Gets or sets the open ai response.</summary>
        /// <value>The OpenAI response.</value>
        [JsonIgnore]
        public OpenAIResponse OpenAIResponse { get; set; }

        /// <summary>
        /// Deserializes the JSON to a OpenAI object type. The type is automatically deduced from
        ///  the <c>object</c> key in the JSON string.
        /// </summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized OpenAI object from the JSON string.</returns>
        public static IHasObject FromJson(string value)
        {
            return JsonUtils.DeserializeObject<IHasObject>(value, OpenAIConfiguration.SerializerSettings);
        }

        /// <summary>Deserializes the JSON to the specified OpenAI object type.</summary>
        /// <typeparam name="T">The type of the OpenAI object to deserialize to.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized OpenAI object from the JSON string.</returns>
        public static T FromJson<T>(string value)
            where T : IOpenAIEntity
        {
            return JsonUtils.DeserializeObject<T>(value, OpenAIConfiguration.SerializerSettings);
        }

        internal void SetRawJObject(JObject rawJObject)
        {
            RawJObject = rawJObject;
        }

        /// <summary>Reports a OpenAI object as a string.</summary>
        /// <returns>
        /// A string representing the OpenAI object, including its JSON serialization.
        /// </returns>
        /// <seealso cref="ToJson"/>
        public override string ToString()
        {
            return
                $"<{GetType().FullName}@{RuntimeHelpers.GetHashCode(this)} id={GetIdString()}> JSON: {ToJson()}";
        }

        /// <summary>Serializes the OpenAI object as a JSON string.</summary>
        /// <returns>An indented JSON string representation of the object.</returns>
        public string ToJson()
        {
            return JsonUtils.SerializeObject(
                this,
                Formatting.Indented,
                OpenAIConfiguration.SerializerSettings);
        }

        private object GetIdString()
        {
            return (from property in GetType().GetTypeInfo().DeclaredProperties where property.Name == "Id" select property.GetValue(this)).FirstOrDefault();
        }
    }

    /// <summary>
    ///   OpenAI Entity.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Generic variant")]
    public abstract class OpenAIEntity<T> : OpenAIEntity
        where T : OpenAIEntity<T>
    {
        /// <summary>Deserializes the JSON to a OpenAI object type.</summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized OpenAI object from the JSON string.</returns>
        // ReSharper disable once ArrangeModifiersOrder
        public static new T FromJson(string value)
        {
            return OpenAIEntity.FromJson<T>(value);
        }
    }
}
