using SP.General.AccesoDatos.Clientes;
using SP.General.IServicios.Clientes;
using SP.General.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SP.General.ServiciosWeb.Clientes
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ClienteServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ClienteServicio.svc o ClienteServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClienteServicio : IClienteServicio
    {
        public List<ClienteModel> ObtenerClientes()
        {
            try
            {
                return ClienteDatos.ObtenerClientes();
            }
            catch (Exception ex) {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        //public ClienteModel InsertarCliente(ClienteModel pCte)
        //{
        //    try
        //    {
        //        return ClienteDatos.InsertarCliente(pCte);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(ex.Message, ex);
        //    }
        //}

        //public ClienteModel ActualizarCliente(ClienteModel pCte)
        //{
        //    try
        //    {
        //        return ClienteDatos.ActualizarCliente(pCte);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(ex.Message, ex);
        //    }
        //}

        //public Int16 EliminarCliente(Int16 pintKeyCli)
        //{
        //    try
        //    {
        //        return ClienteDatos.EliminarCliente(pintKeyCli);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(ex.Message, ex);
        //    }
        //}
    }
}
