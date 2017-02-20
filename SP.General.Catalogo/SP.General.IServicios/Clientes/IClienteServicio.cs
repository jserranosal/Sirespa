using System;
using System.Collections.Generic;

using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using SP.General.Modelo.Clientes;

namespace SP.General.IServicios.Clientes
{
    [ServiceContract]
    public interface IClienteServicio
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "ObtenerClientes",
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json
                  )]
        List<ClienteModel> ObtenerClientes();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //           UriTemplate = "InsertarCliente",
        //           BodyStyle = WebMessageBodyStyle.Wrapped,
        //           RequestFormat = WebMessageFormat.Json,
        //           ResponseFormat = WebMessageFormat.Json
        //          )]
        //ClienteModel InsertarCliente(ClienteModel pCte);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //           UriTemplate = "ActualizarCliente",
        //           BodyStyle = WebMessageBodyStyle.Wrapped,
        //           RequestFormat = WebMessageFormat.Json,
        //           ResponseFormat = WebMessageFormat.Json
        //          )]
        //List<ClienteModel> ActualizarCliente(ClienteModel pCte);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //           UriTemplate = "EliminarCiente",
        //           BodyStyle = WebMessageBodyStyle.Wrapped,
        //           RequestFormat = WebMessageFormat.Json,
        //           ResponseFormat = WebMessageFormat.Json
        //          )]
        //List<ClienteModel> EliminarCiente(Int16 pintKeyCli);

    }
}
