using Microsoft.AspNetCore.Mvc;

namespace CesarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CesarController : ControllerBase
    {
        [HttpPost("cifrar")]
        public IActionResult Cifrar([FromBody] CesarRequest request)
        {
            var resultado = Cesar(request.Mensaje, request.Clave);
            return Ok(new { resultado });
        }

        [HttpPost("descifrar")]
        public IActionResult Descifrar([FromBody] CesarRequest request)
        {
            var resultado = Cesar(request.Mensaje, -request.Clave);
            return Ok(new { resultado });
        }

        private string Cesar(string texto, int desplazamiento)
        {
            string resultado = "";
            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    resultado += (char)(((c - baseChar + desplazamiento + 26) % 26) + baseChar);
                }
                else
                {
                    resultado += c;
                }
            }
            return resultado;
        }
    }

    public class CesarRequest
    {
        public string Mensaje { get; set; } = string.Empty;
        public int Clave { get; set; }
    }
}