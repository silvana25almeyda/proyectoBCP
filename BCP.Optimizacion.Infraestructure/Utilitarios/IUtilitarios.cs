
namespace BCP.Optimizacion.Infraestructure
{
    public interface IUtilitarios
    {
        string Serializar(object entidad);
        Entidad DesSerializar<Entidad>(string data);
        string RetornarUriBaseApiNewLogin();
        string RetornarUriBaseApiInclusionMasiva();
    }
}
