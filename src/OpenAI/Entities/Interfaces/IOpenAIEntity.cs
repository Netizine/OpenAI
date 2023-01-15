namespace OpenAI
{
    /// <summary>
    /// Interface that identifies all entities returned by OpenAI.
    /// </summary>
    public interface IOpenAIEntity
    {
        /// <summary>Gets or sets the open ai response.</summary>
        /// <value>The OpenAI response.</value>
        OpenAIResponse OpenAIResponse { get; set; }
    }
}
