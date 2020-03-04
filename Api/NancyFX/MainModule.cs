using Nancy;

namespace Api.NancyFX
{
    public sealed class MainModule : NancyModule
    {
        public MainModule()
        {
            Get("/", _ => "Mossad HR server");
        }
    }
}