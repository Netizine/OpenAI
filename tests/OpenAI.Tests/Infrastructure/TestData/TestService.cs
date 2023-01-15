namespace OpenAI.Tests.Infrastructure.TestData
{
    using OpenAI;

    public class TestService : Service<Engine>
    {
        public TestService()
            : base(null)
        {
        }

        public override string BasePath => "/engines";
    }
}
