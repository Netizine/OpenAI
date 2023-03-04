// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// OpenAI Chat Roles.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChatRoles
    {
        /// <summary>
        /// User
        /// </summary>
        [JsonProperty("user")]
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// System
        /// </summary>
        [JsonProperty("system")]
        [EnumMember(Value = "system")]
        System,

        /// <summary>
        /// Assistant
        /// </summary>
        [JsonProperty("assistant")]
        [EnumMember(Value = "assistant")]
        Assistant,
    }
}
