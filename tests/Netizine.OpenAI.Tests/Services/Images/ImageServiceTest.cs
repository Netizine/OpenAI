namespace OpenAI.Tests.Services.Images
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class ImageServiceTest : BaseOpenAITest
    {
        private readonly ImageService service;
        private readonly ImageCreateOptions imageCreateOptions;
        private readonly EditImageCreateOptions editCreateOptions;
        private readonly ImageVariationCreateOption variationCreateOptions;

        public ImageServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            service = new ImageService(OpenAIClient);

            imageCreateOptions = new ImageCreateOptions
            {
                Prompt = "A cute baby sea otter",
                N = 2,
                Size = "1024x1024",
            };

            editCreateOptions = new EditImageCreateOptions
            {
                Image = "otters.png",
                ImageSource = System.IO.File.ReadAllBytes("otters.png"),
                Mask = "otters-mask.png",
                MaskSource = System.IO.File.ReadAllBytes("otters-mask.png"),
                Prompt = "A cute baby sea otter wearing a beret",
                N = 2,
                Size = "1024x1024",
            };

            variationCreateOptions = new ImageVariationCreateOption
            {
                Image = "otters.png",
                ImageSource = System.IO.File.ReadAllBytes("otters.png"),
                N = 2,
                Size = "1024x1024",
            };
        }

        [Fact]
        public void Create()
        {
            var image = service.Create(imageCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/generations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var image = await service.CreateAsync(imageCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/generations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public void Edit()
        {
            var image = service.Edit(editCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/edits");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task EditAsync()
        {
            var image = await service.EditAsync(editCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/edits");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public void CreateVariation()
        {
            var image = service.CreateVariation(variationCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/variations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task CreateVariationAsync()
        {
            var image = await service.CreateVariationAsync(variationCreateOptions);
            AssertRequest(HttpMethod.Post, "/v1/images/variations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }
    }
}
