using System.Globalization;

namespace MPO.Code.Common
{
    public class Config
    {
        public static CultureInfo GlobalCulture()
        {
            var culture = new CultureInfo("th-TH", false);
            return culture;
        }

        public static string GetApllicationKey()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ApplicationKey"];
        }

        public static string GetForTest()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ForTest"];
        }
    }
}