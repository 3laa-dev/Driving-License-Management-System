using System.Configuration;



namespace DVLDDataAccessLayer
{
    internal static class DatabaseSettings
    {
        static public string ConnectionString = ConfigurationManager
        .ConnectionStrings["DVLDConnection"]
        .ConnectionString;
    }
}
