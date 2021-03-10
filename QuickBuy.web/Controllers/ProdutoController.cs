using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }        

        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            try
            {
                _produtoRepositorio.Adicionar(produto);

                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("EnviarArquivo")]
        public ActionResult EnviarArquivo()
        {
            try
            {
                var arquivoSelecionado = _httpContextAccessor
                                                .HttpContext
                                                .Request
                                                .Form
                                                .Files["arquivoSelecionado"];

                if(arquivoSelecionado != null)
                {
                    string nomeArquivo = arquivoSelecionado.FileName;
                    string ext = nomeArquivo.Split('.').Last();

                    char[] nomeReduzido = Path
                                        .GetFileNameWithoutExtension(nomeArquivo)
                                        .Take(10).ToArray();

                    string novoNome = $"{new string(nomeReduzido).Replace(' ', '-')}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{ext}";

                    string nomeCompleto = $@"{_hostingEnvironment.WebRootPath}\Files\{novoNome}";                    

                    using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                    {
                        arquivoSelecionado.CopyTo(streamArquivo);
                    }

                    return Json(novoNome);
                }

                return BadRequest("Arquivo não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
