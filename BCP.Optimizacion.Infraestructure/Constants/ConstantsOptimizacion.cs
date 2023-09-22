
namespace BCP.Optimizacion.Infraestructure
{
    public class ConstantsOptimizacion
    {
        //ContentType Api
        public const string ContentTypeJson = "application/json";

        //TimeOut
        public const int timeOutApiExt = 5; //tiempo en minutos

        //Constantes para validaciones con el token
        public const string rolAdministrador = "ADMIN";
        public const string loginUser = "LoginUserName";
        public const string codigoRol = "RoleCode";
        public const string codigoOficina = "OfficeCode";
        public const string codigoAgente = "AgentID";
        public const string aplicacionRenovacion = "RENOV";

        //Contantes para petición con cabecera
        public const string codigoAplicacion = "OIM";
        public const string codigoModulo = "TRON";
        public const string codigoUsuario = "TRON2000";

        //Constante para Api New Login
        public const string rolesUsuarios = "claims/rolesPorUsuario";
        public const string rolAgenteComercial = "AGENTE_COMERCIAL";
        public const string rolEAC = "EAC";

        //Constante para Api Inclusion Masiva
        public const string users = "users";
        public const string user = "user/";
        public const string lot = "lot";
        public const string lots = "lots";
        //user
        public const string userRangeDate = "/datesRange";
        //lotes
        public const string descargarTemplate = "/template";
        public const string estado = "/state";
        public const string filtro = "/searchByFilters";
        public const string crearLoteDetalle = "/execution";
        public const string cancelarLote = "/cancellation";
        public const string procesarLoteDetalle = "/process";
        public const string reportDetalle = "/report";


    }
}
