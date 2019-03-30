using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BolinhaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public FeijoadaResponse RequisitaFeijoada(FeijoadaRequest pedido)
        {
            Image img = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\images\\bolinha-feijoada.jpg");
            
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                img.Save(ms, ImageFormat.Jpeg);
                byte[] bytes = ms.ToArray();

                // Convert byte[] to Base64 string
                string base64 = Convert.ToBase64String(bytes);

                return new FeijoadaResponse()
                {
                    ImagemFeijoada = base64,
                    Email = pedido.Email,
                    Nome = pedido.Nome,
                    Quantidade = pedido.Quantidade,
                    Telefone = pedido.Telefone
                };
            }
        }
    }
}
