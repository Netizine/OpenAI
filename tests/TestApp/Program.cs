using OpenAI;
using System.Diagnostics.Metrics;
using File = OpenAI.File;

//This keys not real so don't bother using it ;-)
//OpenAI.OpenAIConfiguration.ApiKey = "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";
OpenAI.OpenAIConfiguration.ApiKey = "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";
OpenAI.OpenAIConfiguration.OrganizationId = "org-iWOFXcZRTmmvaXG4CNW8JnAF";

//Test engine
//var engineService = new EngineService();
//var engine = engineService.Get("babbage");
//Console.WriteLine(engine.Id);
//OpenAIList<Engine> engineList = engineService.List();
//Console.WriteLine(engineList.Count());

//Test model
//ModelService modelService = new ModelService();
//Model model = modelService.Get("davinci");
//var featureEnabled = model.RawJObject["feature_enabled"];
//Console.WriteLine(model.OwnedBy);
//OpenAIList<Model> models = modelService.List();
//foreach (Model model in models)
//{
//    Console.WriteLine(model.Id);
//}
//Console.WriteLine(models.Data[0].Id);

//Test completion
CompletionService completionService = new CompletionService();
var completionOptions = new CompletionCreateOptions
{
    Prompt = "Say this is a test",
    Model = "text-davinci-003",
    MaxTokens = 7,
    Temperature = 0,
};
Completion completion = completionService.Create(completionOptions);
completionOptions.AddExtraParam("new_feature_enabled", "true");
Console.WriteLine(completion.Id);

//Test edits
//var editService = new EditService();
//var edit = editService.Create(new EditCreateOptions
//{
//    Model = "text-davinci-edit-001",
//    Input = "What day of the wek is it?",
//    Instruction = "Fix the spelling mistakes.",
//});
//Console.WriteLine(edit.Object);

//Test embeddings
//var embeddingService = new EmbeddingService();
//var embedding = embeddingService.Create(new EmbeddingCreateOptions
//{
//    Model = "text-embedding-ada-002",
//    Input = "The food was delicious and the waiter...",
//});
//Console.WriteLine(embedding.Data[0].Object);

//Test images
var imageService = new ImageService();
//var createdImage = imageService.Create(new ImageCreateOptions
//{
//    Prompt = "A cute baby sea otter",
//    N = 2,
//    Size = "1024x1024",
//});
//Console.WriteLine(createdImage.Data[0].Url);
Image editedImage = imageService.Edit(new EditImageCreateOptions
{
    Image = "otters.png",
    ImageSource = System.IO.File.ReadAllBytes("otters.png"),
    Mask = "otters-mask.png",
    MaskSource = System.IO.File.ReadAllBytes("otters-mask.png"),
    Prompt = "A cute baby sea otter wearing a beret",
    N = 2,
    Size = "1024x1024",
});
Console.WriteLine(editedImage.Data[0].Url);
//var variedImage = imageService.CreateVariation(new ImageVariationCreateOption
//{
//    Image = "otters.png",
//    ImageSource = System.IO.File.ReadAllBytes("otters.png"),
//    N = 2,
//    Size = "1024x1024",
//});
//Console.WriteLine(variedImage.Data[0].Url);

//Test files
FileService fileService = new FileService();
var createdFile = fileService.Create(new FileCreateOptions
{
    File = "gpt3_test.jsonl",
    FileSource = System.IO.File.ReadAllBytes("gpt3_test.jsonl"),
    Purpose = "fine-tune",
});
Console.WriteLine(createdFile.Id);
Thread.Sleep(10000);
var file = fileService.Get(createdFile.Id);
Console.WriteLine(file.Id);
var fileList = fileService.List();
Console.WriteLine(fileList.Count());

//Test file content
var fileContentService = new FileContentService();
var fileContent = fileContentService.Get(createdFile.Id);
Console.WriteLine(fileContent.Content);

File deleteFile = fileService.Delete(createdFile.Id, new FileDeleteOptions());
Console.WriteLine(deleteFile.Id);

//Test fine-tunes
var fineTuneService = new FineTuneService();
var fineTune = fineTuneService.Create(new FineTuneCreateOptions
{
    TrainingFile = createdFile.Id,
});
Console.WriteLine(fineTune.Id);
var fineTuneList = fineTuneService.List(new FineTuneListOptions());
Console.WriteLine(fineTuneList.Count());

