using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace HamburguinhoService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var image = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "\\images\\mortadela.jpg");
            return File(image, "image/jpeg");
        }

        // POST api/values
        [HttpPost]
        public HamburquerResponse Post([FromBody]HamburguerRequest request)
        {
            var image = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "\\images\\mortadela.jpg");
            MemoryStream ms = new MemoryStream();
            image.CopyTo(ms);
            return new HamburquerResponse()
            {
                Imagem = ms.ToArray(),
                Cliente = request.Cliente,
                Contato = new Contato()
                {
                    Email = request.Contato.Email,
                    Telefone = request.Contato.Telefone
                },
                Qtd = request.Qtd
            };
        }
    }

    public class HamburguerRequest
    {
        public string Cliente { get; set; }
        public Contato Contato { get; set; }
        public int Qtd { get; set; }
    }

    public class Contato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class HamburquerResponse
    {
        public byte[] Imagem { get; set; }
        public string Cliente { get; set; }
        public Contato Contato { get; set; }
        public int Qtd { get; set; }
    }
}
