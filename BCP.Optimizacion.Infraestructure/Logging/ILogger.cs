using System;

namespace BCP.Optimizacion.Infraestructure
{
    public interface ILogger
    {
        void Configure();
        void Error(object message);
        void Info(object message);
        void Error(object message, Exception exception);
    }
}
