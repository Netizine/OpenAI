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
            this.service = new ImageService(this.OpenAIClient);

            this.imageCreateOptions = new ImageCreateOptions
            {
                Prompt = "A cute baby sea otter",
                N = 2,
                Size = "1024x1024",
            };

            this.editCreateOptions = new EditImageCreateOptions
            {
                Image = "otters.png",
                ImageSource = System.IO.File.ReadAllBytes("otters.png"),
                Mask = "otters-mask.png",
                MaskSource = System.IO.File.ReadAllBytes("otters-mask.png"),
                Prompt = "A cute baby sea otter wearing a beret",
                N = 2,
                Size = "1024x1024",
            };

            this.variationCreateOptions = new ImageVariationCreateOption
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
            var image = this.service.Create(this.imageCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/generations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var image = await this.service.CreateAsync(this.imageCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/generations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public void Edit()
        {
            var image = this.service.Edit(this.editCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/edits");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task EditAsync()
        {
            var image = await this.service.EditAsync(this.editCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/edits");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public void CreateVariation()
        {
            var image = this.service.CreateVariation(this.variationCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/variations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }

        [Fact]
        public async Task CreateVariationAsync()
        {
            var image = await this.service.CreateVariationAsync(this.variationCreateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/images/variations");
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }
    }
}
