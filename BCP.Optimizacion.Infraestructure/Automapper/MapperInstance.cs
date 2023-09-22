using AutoMapper;
using AutoMapper.Configuration;
using System.Reflection;

namespace BCP.Optimizacion.Infraestructure
{
    public class MapperInstance : IMapperInstance
    {
        private IConfigurationProvider _configuracionProveedor;
        private IMapper _mapper;
        private MapperConfigurationExpression _configuracionExpresion;

        /// <summary>
        /// Crea la instancia del Helper registrando todos los perfiles del Assembly enviado para la configuración de Mapeos.
        /// </summary>
        /// <param name="assembly">Assembly que contiene todos las clases perfiles (derivadas de AutoMapper.Profile) de configuración</param>
        public MapperInstance(Assembly assembly)
        {
            _configuracionExpresion = new MapperConfigurationExpression();
            _configuracionExpresion.AddProfiles(assembly);

            CrearMapeador();
        }

        private void CrearMapeador()
        {
            _configuracionProveedor = new MapperConfiguration(_configuracionExpresion);
            _mapper = new Mapper(_configuracionProveedor);
        }

        #region Implementación de Interface IMapperInstance
        /// <summary>
        /// Devuelve la intancia actual del Mapper.
        /// </summary>
        /// <returns>Instancia de AutoMapper.Mapper</returns>
        public IMapper Mapper()
        {
            return _mapper;
        }

        public IConfigurationProvider Config()
        {
            return _configuracionProveedor;
        }

        /// <summary>
        /// Realiza el mapeo del objeto Origen hacia el objeto Destino, la configuración del mapeo se debio realizar previamente dentro del perfil
        /// </summary>
        /// <typeparam name="Origen">Tipo Origen</typeparam>
        /// <typeparam name="Destino">Tipo Destino</typeparam>
        /// <param name="objetoOrigen">Intancia de objeto de tipo Origen</param>
        /// <returns>Instancia de objeto de tipo Destino</returns>
        public Destino Mapear<Origen, Destino>(Origen objetoOrigen)
        {
            return _mapper.Map<Origen, Destino>(objetoOrigen);
        }
        #endregion
    }
}
