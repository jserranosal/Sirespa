using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using SP.General.Modelo.TiposCliente;

namespace SP.General.Modelo.Clientes
{
    [Serializable]
    [DataContract]
    public class ClienteModel : TipoClienteModel
    {
        [DisplayName("ID")]
        [DataMember(Name = "KEYCLI")]
        public Int16 KEYCLI { get; set; }

        [DisplayName("RFC")]
        [DataMember(Name = "RFCCLI")]
        public string RFCCLI { get; set; }

        [DisplayName("NOMBRE_CLIENTE")]
        [DataMember(Name = "NOMCLI")]
        public string NOMCLI { get; set; }

        [DisplayName("AP_PATERNO")]
        [DataMember(Name = "APEPAT")]
        public string APEPAT { get; set; }

        [DisplayName("AP_MATERNO")]
        [DataMember(Name = "APEMAT")]
        public string APEMAT { get; set; }

        [DisplayName("DOMILICIO")]
        [DataMember(Name = "DOMCLI")]
        public string DOMCLI { get; set; }

        [DisplayName("NUM_EXTERIOR")]
        [DataMember(Name = "NUMEXT")]
        public string NUMEXT { get; set; }

        [DisplayName("NUM_INTERIOR")]
        [DataMember(Name = "NUMINT")]
        public string NUMINT { get; set; }

        [DisplayName("COLONIA")]
        [DataMember(Name = "COLONI")]
        public string COLONI { get; set; }

        [DisplayName("COD_POSTAL")]
        [DataMember(Name = "CODPOS")]
        public string CODPOS { get; set; }

        [DisplayName("PAIS")]
        [DataMember(Name = "NOMPAI")]
        public string NOMPAI { get; set; }

        [DisplayName("ESTDO")]
        [DataMember(Name = "NOMEDO")]
        public string NOMEDO { get; set; }

        [DisplayName("CIUDAD")]
        [DataMember(Name = "NOMCIU")]
        public string NOMCIU { get; set; }

        [DisplayName("ULTIMA_ACTUALIZACION")]
        [DataMember(Name = "CLIFUC")]
        public DateTime CLIFUC { get; set; }

        [DisplayName("FECHA_ALTA")]
        [DataMember(Name = "CLIFAL")]
        public DateTime CLIFAL { get; set; }

    }
}
