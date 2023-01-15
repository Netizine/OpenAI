﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OpenAI.Tests.Services.FineTunes
{
    public class FineTuneEventsServiceTest : BaseOpenAITest
    {
        private const string FineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

        private readonly FineTuneEventsService service;

        public FineTuneEventsServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new FineTuneEventsService(this.OpenAIClient);
        }

        [Fact]
        public void Get()
        {
            var fineTuneEvents = this.service.Get(FineTuneId);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/events");
            Assert.NotNull(fineTuneEvents);
            Assert.NotNull(fineTuneEvents.Data);
            Assert.Equal("list", fineTuneEvents.Object);
            Assert.Equal("fine-tune-event", fineTuneEvents.Data.FirstOrDefault().Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var fineTuneEvents = await this.service.GetAsync(FineTuneId);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/events");
            Assert.NotNull(fineTuneEvents);
            Assert.NotNull(fineTuneEvents.Data);
            Assert.Equal("list", fineTuneEvents.Object);
            Assert.Equal("fine-tune-event", fineTuneEvents.Data.FirstOrDefault().Object);
        }
    }
}
