using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;


var modelId = "gpt-4o-mini";
var apiKey = "";

var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId, apiKey);

builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));

Kernel kernel = builder.Build();
var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

kernel.Plugins.AddFromType<fridgeEcosystem.FoodsPlugin>("Foods");

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new() 
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

var history = new ChatHistory();

string? userInput;
do {
    Console.Write("User > ");
    userInput = Console.ReadLine();

    history.AddUserMessage(userInput!);

    var result = await chatCompletionService.GetChatMessageContentAsync(
        history,
        executionSettings: openAIPromptExecutionSettings,
        kernel: kernel);

    Console.WriteLine("Assistant > " + result);
    history.AddMessage(result.Role, result.Content ?? string.Empty);
} while (userInput is not null);