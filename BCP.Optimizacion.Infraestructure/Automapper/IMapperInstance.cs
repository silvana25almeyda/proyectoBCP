using AutoMapper;

namespace BCP.Optimizacion.Infraestructure
{
    public interface IMapperInstance
    {
        IConfigurationProvider Config();
        Destino Mapear<Origen, Destino>(Origen objetoOrigen);
        IMapper Mapper();
    }
}
