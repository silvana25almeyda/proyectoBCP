using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Configuration;
using System.Data.OracleClient;

namespace BCP.Optimizacion.Infraestructure
{
    public class Logger : ILogger
    {
        private static ILog _log { get; set; }

        private string _rutaNombreArchivo = "";
        private string _patronRegistro = "";
        private string _tamanioMaximo = "";
        private int _cantidadBackups = 0;

        public Logger()
        {
            _log = LogManager.GetLogger(typeof(Logger));
            _rutaNombreArchivo = ConfigurationManager.AppSettings["LoggerNombreRutaArchivo"].ToString();
            _patronRegistro = ConfigurationManager.AppSettings["LoggerPatronRegistro"].ToString();
            _tamanioMaximo = ConfigurationManager.AppSettings["LoggerTamanioMaximo"].ToString();
            _cantidadBackups = int.Parse(ConfigurationManager.AppSettings["LoggerCantidadBackups"].ToString());

            Configure();
        }

        public void Configure()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = _patronRegistro;
            patternLayout.ActivateOptions();

            hierarchy.Root.RemoveAllAppenders();
            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = _rutaNombreArchivo;
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = _cantidadBackups;
            //------------------------------------------------------
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.MaximumFileSize = _tamanioMaximo;
            roller.StaticLogFileName = true;
            //------------------------------------------------------
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

        public void Error(object message, Exception exception)
        {
            if (exception is OracleException)
            {
                var oracleException = (OracleException)exception;
                var mensajeErrorSql = string.Format("Error en BD. Origen: {0}, Código: {1}, Exception: {2}, Método: {3}, Mensaje: {4}",

                oracleException.Source,
                oracleException.Code,
                oracleException.InnerException,
                oracleException.TargetSite,
                oracleException.Message);

                _log.Error(mensajeErrorSql);
            }

            _log.Error(message, exception);
        }

        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }
    }
}
