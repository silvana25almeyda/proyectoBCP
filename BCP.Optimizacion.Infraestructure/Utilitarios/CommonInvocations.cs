using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure
{
    public class CommonInvocations : ICommonInvocations
    {
        private readonly IUtilitarios _utilitarios;

        public CommonInvocations(IUtilitarios utilitarios)
        {
            _utilitarios = utilitarios;
        }

        public async Task<HttpResponseMessage> GetRecurso(string url)
        {
            HttpResponseMessage respuestaRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var httpclient = new HttpClient())
            {
                httpclient.Timeout = TimeSpan.FromMinutes(ConstantsOptimizacion.timeOutApiExt);
                respuestaRequest = await httpclient.GetAsync(url);
            }
            return respuestaRequest;
        }

        public async Task<HttpResponseMessage> GetRecurso(string url, string token)
        {
            HttpResponseMessage respuestaRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls12;
            //ServicePointManager.Expect100Continue = true;

            using (var httpclient = new HttpClient())
            {
                httpclient.Timeout = TimeSpan.FromMinutes(ConstantsOptimizacion.timeOutApiExt);
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                respuestaRequest = await httpclient.GetAsync(url);
            }
            return respuestaRequest;
        }

        public async Task<HttpResponseMessage> PostBodyResultado<Entidad>(string url, Entidad entidad)
        {
            string data = _utilitarios.Serializar(entidad);
            HttpResponseMessage respuestaRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var httpclient = new HttpClient())
            {
                httpclient.Timeout = TimeSpan.FromMinutes(ConstantsOptimizacion.timeOutApiExt);
                HttpContent contenidoRequest = new StringContent(data, Encoding.UTF8, ConstantsOptimizacion.ContentTypeJson);
                respuestaRequest = await httpclient.PostAsync(url, contenidoRequest);
            }

            return respuestaRequest;
        }

        public async Task<HttpResponseMessage> PutBodyResultado<Entidad>(string url, Entidad entidad)
        {
            string data = _utilitarios.Serializar(entidad);
            HttpResponseMessage respuestaRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var httpclient = new HttpClient())
            {
                httpclient.Timeout = TimeSpan.FromMinutes(ConstantsOptimizacion.timeOutApiExt);
                HttpContent contenidoRequest = new StringContent(data, Encoding.UTF8, ConstantsOptimizacion.ContentTypeJson);
                respuestaRequest = await httpclient.PutAsync(url, contenidoRequest);
            }

            return respuestaRequest;
        }

        public async Task<HttpResponseMessage> DeleteRecurso<Entidad>(string url, Entidad entidad)
        {
            string data = _utilitarios.Serializar(entidad);
            HttpResponseMessage respuestaRequest;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var httpclient = new HttpClient())
            {
                httpclient.Timeout = TimeSpan.FromMinutes(ConstantsOptimizacion.timeOutApiExt);
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(data, Encoding.UTF8, ConstantsOptimizacion.ContentTypeJson),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url)
                };
                respuestaRequest = await httpclient.SendAsync(request);
            }
            return respuestaRequest;
        }
    }
}
