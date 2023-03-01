using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using OpenAI.Mock.Models.Requests;
using OpenAI.Mock.Models;
using OpenAI.Mock.Models.Responses;
using FluentValidation.Results;

namespace OpenAI.Mock.Endpoints;

public class CreateChatCompletionEndpoint : Endpoint<ChatGPT3CompletionRequest, ChatGPT3CompletionResponse> 
{

    public override void Configure() {
        Post("/v1/chat/completions");
        AllowAnonymous();
        PreProcessors(new SecurityProcessor<ChatGPT3CompletionRequest>());
    }

    public override async Task HandleAsync(ChatGPT3CompletionRequest req, CancellationToken ct) {

        var modelIsValid = false;
        if (req.Model == "gpt-3.5-turbo")
        {
            modelIsValid = true;
        }
        else if (req.Model == "gpt-3.5-turbo-0301") {
            modelIsValid = true;
        }

        if (!modelIsValid) {
            ValidationFailures.Add(new ValidationFailure("invalid_request_error", "That model does not exist", req.Model));
        }

        ThrowIfAnyErrors();

        var completionId = RandomIdGenerator.GenerateRandomId("chatcmpl-");
        var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        var secondsSinceEpoch = (int)t.TotalSeconds;
        var chatMessage = new ChatCompletionMessage
        {
            Role = ChatRoles.Assistant,
            Content = "As an AI language model, I do not have a personal belief or conviction about the meaning of life. The meaning of life is a philosophical and existential inquiry that has been debated by countless thinkers throughout history, with no clear-cut answer. Different individuals and cultures may have different answers or interpretations. Some believe the meaning of life is to find happiness or personal fulfillment, while others believe it is to achieve spiritual transcendence or to make a positive impact on the world. Ultimately, the meaning of life is subjective and may vary from person to person."
        };
        var choices = new List<ChatChoice>
        {
            new ChatChoice(chatMessage,0, "length")
        };
        var usage = new Usage(5, 7, 12);
        var response = new ChatGPT3CompletionResponse(completionId, secondsSinceEpoch, req.Model, choices, usage);
        await SendAsync(response, 200, ct);
    }
}