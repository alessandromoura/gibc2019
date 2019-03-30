using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BolinhaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        FeijoadaResponse RequisitaFeijoada(FeijoadaRequest pedido);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class FeijoadaRequest
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Telefone { get; set; }

        [DataMember]
        public int Quantidade { get; set; }
    }

    [DataContract]
    public class FeijoadaResponse
    {
        [DataMember]
        public string ImagemFeijoada { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Telefone { get; set; }

        [DataMember]
        public int Quantidade { get; set; }
    }
}
