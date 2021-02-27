using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.web.Controllers
{    
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public ActionResult post()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                Usuario usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                    return Ok(usuarioRetorno);

                return BadRequest("Usuario ou senha inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
