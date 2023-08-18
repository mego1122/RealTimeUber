namespace RealTimeUber.Configuration
{
     static class ConfigurationManagerr
    {
        public static IConfiguration AppSetting { get; set; }
        static ConfigurationManagerr()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
