using System.Configuration;

namespace DAL
{
    public static class ConfigurationAccess
    {
        public static string GetConnectionString(string name) => ConfigurationManager.ConnectionStrings[name].ConnectionString;

        public static string GetProviderString(string name) => ConfigurationManager.ConnectionStrings[name].ProviderName;
    }
}
