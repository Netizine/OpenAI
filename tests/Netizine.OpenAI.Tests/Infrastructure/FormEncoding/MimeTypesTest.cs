namespace OpenAI.Tests
{
    using System;
    using OpenAI.Infrastructure.FormEncoding;
    using Xunit;

    public class MimeTypesTest : BaseOpenAITest
    {
        [Fact]
        public void GetMimeType_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MimeTypes.GetMimeType(null));
        }

        [Fact]
        public void GetMimeType_KnownExtension_Success()
        {
            Assert.Equal("image/png", MimeTypes.GetMimeType(".png"));
        }

        [Fact]
        public void GetMimeType_KnownExtensionWithoutLeadingDot_Success()
        {
            Assert.Equal("image/png", MimeTypes.GetMimeType("png"));
        }

        [Fact]
        public void GetMimeType_UnknownExtension_Success()
        {
            Assert.Equal("application/octet-stream", MimeTypes.GetMimeType("foo"));
        }
    }
}
