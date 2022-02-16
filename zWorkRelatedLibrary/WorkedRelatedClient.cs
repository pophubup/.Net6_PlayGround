using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace zWorkRelatedLibrary
{
    public static  class WorkedRelatedClient
    {
        public static IServiceCollection AddWorkedRelatedClient(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<WordUntil>();
            var buidler = service.BuildServiceProvider();
           buidler.GetService<WordUntil> ().ValueReplaceBySeed(configuration["words:SEED"]);
           // buidler.GetService<WordUntil>().RTFFormatToReplaceValue(configuration["words:RTF"]);
            return service;
        }
    }
}
