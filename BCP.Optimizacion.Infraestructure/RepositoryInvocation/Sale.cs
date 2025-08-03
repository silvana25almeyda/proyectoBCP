using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure
{
    public class Sale : ISale
    {
        string cadenaconexion = ConfigurationManager.ConnectionStrings["BCPEntities"].ConnectionString;
        private readonly ICommonInvocations _commonInvocations;
        private readonly IUtilitarios _utilitarios;

        public Sale(ICommonInvocations commonInvocations, IUtilitarios utilitarios)
        {
            _commonInvocations = commonInvocations;
            _utilitarios = utilitarios;
        }

        public SaleResponse crearVenta(SaleRequest saleRequest)
        {
            var resultado = new SaleResponse();
            HttpResponseMessage respuestaRequest;

            //
            bool success = false;
            SqlConnection LaConexion = null;
            SqlTransaction LaTransaccion = null;

            //iniciamos un try catch
            try
            {
                //seguimos con la conexion
                LaConexion = new SqlConnection();
                //asignamos a la conexión la cadena de conexión que declaramos anteriormente
                LaConexion.ConnectionString = cadenaconexion;
                //se abre la conexión
                LaConexion.Open();
                //se inicia la transacción
                LaTransaccion = LaConexion.BeginTransaction(System.Data.IsolationLevel.Serializable);
                //especificamos el comando, en este caso el nombre del Procedimiento Almacenado
                SqlCommand comando = new SqlCommand("RegistrarVenta", LaConexion, LaTransaccion);
                //se indica al tipo de comando que es de tipo procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;
                //se limpian los parámetros
                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@IdPeriodo", saleRequest.IdPeriodo);
                comando.Parameters.AddWithValue("IdProductoFinanciero", saleRequest.IdProductoFinanciero);
                comando.Parameters.AddWithValue("IdAsesorComercial", saleRequest.IdAsesorComercial);
                comando.Parameters.AddWithValue("IdCliente", saleRequest.IdCliente);
                comando.Parameters.AddWithValue("MontoDesembolsado", saleRequest.MontoDesembolsado);
                //declaramos el parámetro de retorno
                SqlParameter ValorRetorno = new SqlParameter("Resultado", SqlDbType.Int);
                //asignamos el valor de retorno
                ValorRetorno.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ValorRetorno);
                //executamos la consulta
                comando.ExecuteNonQuery();

                resultado.codigoResponse = Convert.ToInt32(ValorRetorno.Value);
                resultado.message = "OK";
                success= Convert.ToBoolean(ValorRetorno.Value);
            }
            catch (Exception ex)
            {
                resultado.codigoResponse = 0;
                resultado.message = ex.Message;
                success = false;
            }
            finally
            {
                if (success)
                {
                    //se realiza la transacción
                    LaTransaccion.Commit();
                    //cerramos la conexión
                    LaConexion.Close();
                }
                else
                {
                    //se deshace la transacción
                    LaTransaccion.Rollback();
                    //cerramos la conexión
                    LaConexion.Close();
                }
            }
            return resultado;
        }

    }
}
