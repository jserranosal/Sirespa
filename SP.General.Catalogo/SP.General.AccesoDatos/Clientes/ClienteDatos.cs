using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SP.General.Modelo.Clientes;



namespace SP.General.AccesoDatos.Clientes
{
    public static class ClienteDatos
    {
        public static List<ClienteModel> ObtenerClientes()
        {
            Database database;
            DbCommand dbCommand;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            List<ClienteModel> lstClientes = null;
            lstClientes = new List<ClienteModel>();
            try
            {
                
                database = factory.Create(ClientesConstantesBD.strConexion);
                dbCommand = database.GetStoredProcCommand(ClientesConstantesBD.strCLIENTES_OBTENER);

                using (IDataReader objReader = database.ExecuteReader(dbCommand)) {
                    lstClientes = CreaClientes(objReader);
                }

                if (lstClientes == null)
                    return null;
                else
                    return lstClientes;
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message, exp);
            }
            finally {
                database = null;
                dbCommand = null;
                factory = null;
                lstClientes = null;
            }
        }
        private static List<ClienteModel> CreaClientes(IDataReader objReader)
        {
            List<ClienteModel> lstClientes = new List<ClienteModel>();
            ClienteModel Cte;
            bool isnull = false;
            try
            {
                while (objReader.Read())
                {
                    isnull = false;
                    Cte = new ClienteModel();
                    Cte.KEYCLI = Convert.ToInt16(objReader[ClientesConstantesBD.strKEYCLI]);
                    Cte.KEYTCP = Convert.ToInt16(objReader[ClientesConstantesBD.strKEYTCP]);
                    Cte.TPCDES = Convert.ToString(objReader[ClientesConstantesBD.strTPCDES]);
                    Cte.RFCCLI = Convert.ToString(objReader[ClientesConstantesBD.strRFCCLI]);
                    Cte.NOMCLI = Convert.ToString(objReader[ClientesConstantesBD.strNOMCLI]);
                    Cte.APEPAT = Convert.ToString(objReader[ClientesConstantesBD.strAPEPAT]);
                    Cte.APEPAT = Convert.ToString(objReader[ClientesConstantesBD.strAPEMAT]);
                    Cte.DOMCLI = Convert.ToString(objReader[ClientesConstantesBD.strDOMCLI]);
                    Cte.NUMEXT = Convert.ToString(objReader[ClientesConstantesBD.strNUMEXT]);
                    Cte.NUMINT = objReader[ClientesConstantesBD.strNUMINT] != DBNull.Value ?
                                 Convert.ToString(objReader[ClientesConstantesBD.strNUMINT]) : Cte.NUMINT = null;
                    Cte.COLONI = Convert.ToString(objReader[ClientesConstantesBD.strCOLONI]);
                    Cte.CODPOS = Convert.ToString(objReader[ClientesConstantesBD.strCODPOS]);
                    Cte.NOMPAI = Convert.ToString(objReader[ClientesConstantesBD.strNOMPAI]);
                    Cte.NOMEDO = Convert.ToString(objReader[ClientesConstantesBD.strNOMEDO]);
                    Cte.NOMCIU = Convert.ToString(objReader[ClientesConstantesBD.strNOMCIU]);
                    Cte.FEULAC = Convert.ToDateTime(objReader[ClientesConstantesBD.strCLIFUC]);
                    Cte.FECALT = Convert.ToDateTime(objReader[ClientesConstantesBD.strCLIFAL]);

                    lstClientes.Add(Cte);
                }

                if (isnull)
                    return null;
                else
                    return lstClientes;
            }
            catch (Exception exp)
            {
                //throw new ApplicationException(exp.Message, exp);
                return null;
            }
            finally {
                Cte = null;
                lstClientes = null;
            }

        }

        public static ClienteModel InsertarCliente(ClienteModel pCte)
        {
            Database database;
            DbCommand dbCommand;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            ClienteModel Cte = pCte;
            try
            {
                database = factory.Create(ClientesConstantesBD.strConexion);
                dbCommand = database.GetStoredProcCommand(ClientesConstantesBD.strCLIENTES_INSERTAR);
                database.AddInParameter(dbCommand, "P_IN_KEYTCP", DbType.Int16, pCte.KEYTCP);
                database.AddInParameter(dbCommand, "P_IN_RFCCLI", DbType.String, pCte.RFCCLI);
                database.AddInParameter(dbCommand, "P_IN_NOMBRE", DbType.String, pCte.NOMCLI);
                database.AddInParameter(dbCommand, "P_IN_APEPAT", DbType.String, pCte.APEPAT);
                database.AddInParameter(dbCommand, "P_IN_APEMAT", DbType.String, pCte.APEMAT);
                database.AddInParameter(dbCommand, "P_IN_DOMICI", DbType.String, pCte.DOMCLI);
                database.AddInParameter(dbCommand, "P_IN_NUMEXT", DbType.String, pCte.NUMEXT);
                database.AddInParameter(dbCommand, "P_IN_NUMINT", DbType.String, pCte.NUMINT);
                database.AddInParameter(dbCommand, "P_IN_COLONI", DbType.String, pCte.COLONI);
                database.AddInParameter(dbCommand, "P_IN_CODPOS", DbType.String, pCte.CODPOS);
                database.AddInParameter(dbCommand, "P_IN_NOMPAI", DbType.String, pCte.NOMPAI);
                database.AddInParameter(dbCommand, "P_IN_NOMEDO", DbType.String, pCte.NOMEDO);
                database.AddInParameter(dbCommand, "P_IN_NOMCIU", DbType.String, pCte.NOMCIU);

                database.AddOutParameter(dbCommand, "P_OUT_KEYCLI", DbType.Int16, 0);
                database.AddOutParameter(dbCommand, "P_OUT_FEULAC", DbType.DateTime, 20);
                database.ExecuteNonQuery(dbCommand);

                Cte.KEYCLI = Convert.ToInt16(database.GetParameterValue(dbCommand, "P_OUT_KEYCLI"));
                Cte.FECALT = Convert.ToDateTime(database.GetParameterValue(dbCommand, "P_OUT_FEULAC"));
                Cte.FEULAC = Convert.ToDateTime(database.GetParameterValue(dbCommand, "P_OUT_FEULAC"));

                if (Cte.FECALT == null)
                    return null;
                else
                    return Cte;
            }
            catch (Exception exp) {
                // throw new ApplicationException(exp.Message, exp);
                return null;
            }
            finally {
                database = null;
                dbCommand = null;
                factory = null;
                Cte = null;
            }
        }

        public static ClienteModel ActualizarCliente(ClienteModel pCte)
        {
            Database database;
            DbCommand dbCommand;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            ClienteModel Cte = pCte;
            try
            {
                database = factory.Create(ClientesConstantesBD.strConexion);
                dbCommand = database.GetStoredProcCommand(ClientesConstantesBD.strCLIENTES_INSERTAR);
                database.AddInParameter(dbCommand, "P_IN_KEYCLI", DbType.Int16, pCte.KEYCLI);
                database.AddInParameter(dbCommand, "P_IN_KEYTCP", DbType.Int16, pCte.KEYTCP);
                database.AddInParameter(dbCommand, "P_IN_RFCCLI", DbType.String, pCte.RFCCLI);
                database.AddInParameter(dbCommand, "P_IN_NOMBRE", DbType.String, pCte.NOMCLI);
                database.AddInParameter(dbCommand, "P_IN_APEPAT", DbType.String, pCte.APEPAT);
                database.AddInParameter(dbCommand, "P_IN_APEMAT", DbType.String, pCte.APEMAT);
                database.AddInParameter(dbCommand, "P_IN_DOMICI", DbType.String, pCte.DOMCLI);
                database.AddInParameter(dbCommand, "P_IN_NUMEXT", DbType.String, pCte.NUMEXT);
                database.AddInParameter(dbCommand, "P_IN_NUMINT", DbType.String, pCte.NUMINT);
                database.AddInParameter(dbCommand, "P_IN_COLONI", DbType.String, pCte.COLONI);
                database.AddInParameter(dbCommand, "P_IN_CODPOS", DbType.String, pCte.CODPOS);
                database.AddInParameter(dbCommand, "P_IN_NOMPAI", DbType.String, pCte.NOMPAI);
                database.AddInParameter(dbCommand, "P_IN_NOMEDO", DbType.String, pCte.NOMEDO);
                database.AddInParameter(dbCommand, "P_IN_NOMCIU", DbType.String, pCte.NOMCIU);

                database.AddOutParameter(dbCommand, "P_OUT_FEULAC", DbType.DateTime, 20);
                database.ExecuteNonQuery(dbCommand);

                Cte.FEULAC = Convert.ToDateTime(database.GetParameterValue(dbCommand, "P_OUT_FEULAC"));

                if (Cte.FEULAC == null)
                    return null;
                else
                    return Cte;
            }
            catch (Exception exp) {
                // throw new ApplicationException(exp.Message, exp);
                return null;
            }
            finally {
                database = null;
                dbCommand = null;
                factory = null;
                Cte = null;
            }
        }

        public static Int16 EliminarCiente(Int16 pintKeyCli)
        {
            Database database;
            DbCommand dbCommand;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Int16 intRespuesta = 0;
            try
            {
                database = factory.Create(ClientesConstantesBD.strConexion);
                dbCommand = database.GetStoredProcCommand(ClientesConstantesBD.strCLIENTES_INSERTAR);
                database.AddInParameter(dbCommand, "P_IN_KEYCLI", DbType.Int16, pintKeyCli);

                database.AddOutParameter(dbCommand, "P_OUT_FEULAC", DbType.DateTime, 20);
                database.ExecuteNonQuery(dbCommand);

                intRespuesta = Convert.ToInt16(database.GetParameterValue(dbCommand, "P_OUT_RESPUESTA"));

                return intRespuesta;
            }
            catch (Exception exp)
            {
                //throw new ApplicationException(exp.Message, exp);
                return intRespuesta;
            }
            finally {
                database = null;
                dbCommand = null;
                factory = null;
            }
        }
    }
}
