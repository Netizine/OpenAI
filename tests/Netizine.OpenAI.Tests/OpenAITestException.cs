namespace OpenAI.Tests
{
    using System;

    /// <summary>
    /// Represents errors that are related to tests themselves rather than the
    /// features under test.
    /// </summary>
    public class OpenAITestException : Exception
    {
        public OpenAITestException()
        {
        }

        public OpenAITestException(string message)
            : base(message)
        {
        }
    }
}
