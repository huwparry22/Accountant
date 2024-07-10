using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    public static class HostHelper
    {
        public static void SetupApplicationStore(this IHost host)
        {
            host.Services.SetupDatabase();
        }
    }
}
