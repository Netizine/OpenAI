using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models.Responses;

public class EditResponse
{
    public EditResponse(int created, List<Choice> choices, Usage usage)
    {
        Object = "edit";
        Created = created;
        Choices = choices;
        Usage = usage;
    }


    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    public List<Choice> Choices { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }
}
