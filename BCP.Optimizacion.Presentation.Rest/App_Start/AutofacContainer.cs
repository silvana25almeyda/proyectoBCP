using Autofac;
using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Application.Implementation;
using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Implementation;
using BCP.Optimizacion.Infraestructure;
using BCP.Optimizacion.Infraestructure.WebClient.Rest.NewLogin;

namespace BCP.Optimizacion.Presentation.Rest
{
    public class AutofacContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Automapper
            builder.Register(c => new MapperInstance(GetType().Assembly))
                 .As<IMapperInstance>()
                 .SingleInstance();
            #endregion

            #region Logger
            builder.RegisterType<Logger>()
                .As<ILogger>()
                .SingleInstance();
            #endregion

            #region Capa infraestructura
            builder.RegisterType<Utilitarios>()
                .As<IUtilitarios>()
                .SingleInstance();

            builder.RegisterType<CommonInvocations>()
                .As<ICommonInvocations>()
                .SingleInstance();

            builder.RegisterType<OperacionLogin>()
                .As<IOperacionLogin>()
                .SingleInstance();
            #endregion

            #region Capa Dominio
            builder.RegisterType<BaseDomain>()
                .As<IBaseDomain>()
                .SingleInstance();

            builder.RegisterType<User>()
                .As<IUser>()
                .SingleInstance();
            
            builder.RegisterType<Sale>()
                .As<ISale>()
                .SingleInstance();
            
            #endregion

            #region Capa Aplicación

            builder.RegisterType<ServiceBaseAplication>()
                .As<IServiceBaseAplication>()
                .SingleInstance();

            builder.RegisterType<ServiceUser>()
                .As<IServiceUser>()
                .SingleInstance();

            builder.RegisterType<ServiceSale>()
                .As<IServiceSale>()
                .SingleInstance();

            #endregion

            #region Capa de Servicio

            #endregion
        }
    }
}