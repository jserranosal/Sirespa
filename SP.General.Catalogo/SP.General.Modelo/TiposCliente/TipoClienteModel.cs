using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SP.General.Modelo.TiposCliente
{
    [Serializable]
    [DataContract]
    public class TipoClienteModel
    {

        [DisplayName("TPO_CTE")]
        [DataMember(Name = "KEYTCP")]
        public Int16 KEYTCP { get; set; }

        [DisplayName("TIPO_CLIENTE")]
        [DataMember(Name = "TPCDES")]
        public string TPCDES { get; set; }

        [DisplayName("ULTIMA_ACTUALIZACION")]
        [DataMember(Name = "TPCFUC")]
        public DateTime FEULAC { get; set; }

        [DisplayName("FECHA_ALTA")]
        [DataMember(Name = "TPCFAL")]
        public DateTime FECALT { get; set; }
    }
}
