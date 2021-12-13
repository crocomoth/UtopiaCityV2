namespace UtopiaCity.Common
{
    /// <summary>
    /// Class which stores values from appsettings.json
    /// </summary>
    public class AppConfig
    {
        public const string Name = "AppConfig";

        public bool ClearDb { get; set; }
        public bool SeedDb { get; set; }
        public int CacheExpiration { get; set; }
    }
}
