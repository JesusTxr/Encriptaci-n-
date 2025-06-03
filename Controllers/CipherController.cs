using Microsoft.AspNetCore.Mvc;
using CesarApi.Models;
using CesarApi.Services;

namespace CesarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CipherController : ControllerBase
    {
        private readonly CipherService _cipherService;

        public CipherController(CipherService cipherService)
        {
            _cipherService = cipherService;
        }

        [HttpPost("process")]
        public IActionResult ProcessMessage([FromBody] CipherRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                return BadRequest("El mensaje no puede estar vacío");

            var result = _cipherService.ProcessMessage(request.Message, request.Shift, request.Decrypt);
            return Ok(new { result });
        }
    }
} 