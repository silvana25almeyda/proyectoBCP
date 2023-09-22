using System.Configuration;

namespace BCP.Optimizacion.Infraestructure
{
    public class UrisApiBase
    {
        public static string ApiRestNewLogin
        {
            get { return ConfigurationManager.AppSettings["ApiRestNewLogin"].ToString(); }
        }

        public static string ApiRestInclusionMasiva
        {
            get { return ConfigurationManager.AppSettings["ApiJavaRestExterno"].ToString(); }
        }
    }
}
