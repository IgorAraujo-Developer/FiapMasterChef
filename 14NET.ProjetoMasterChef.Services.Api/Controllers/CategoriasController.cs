using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _14NET.ProjetoMasterChef.Domain.Entities;
using _14NET.ProjetoMasterChef.Infra.Data.Context;
using _14NET.ProjetoMasterChef.Application.Interfaces;
using _14NET.ProjetoMasterChef.Application.ViewModels;

namespace _14NET.ProjetoMasterChef.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {        
        private readonly ICategoriaAppService _appService;

        public CategoriasController(ICategoriaAppService appService)
        {
            _appService = appService;            
        }

        // GET: api/Categorias
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaViewModel>> GetCategorias()
        {
            return _appService.ObterTodos().Result.ToList();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public ActionResult<CategoriaViewModel> GetCategoria(Guid id)
        {
            var categoria = _appService.ObterPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }


        // POST: api/Categorias
        [HttpPost]
        public ActionResult<CategoriaViewModel> PostCategoria(CategoriaViewModel categoria)
        {
            var retorno = _appService.Adicionar(categoria);            

            return CreatedAtAction("GetCategoria", new { id = retorno.Id }, retorno);
        }

        [HttpPut("{id}")]
        public ActionResult<ReceitaViewModel> PutReceita(int id, [FromBody]CategoriaViewModel categoria)
        {
            _appService.Atualizar(categoria);

            return Ok(categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public ActionResult<CategoriaViewModel> DeleteCategoria(Guid id)
        {
            var categoria = _appService.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _appService.Remover(id);
            

            return categoria;
        }

        private bool CategoriaExists(Guid id)
        {
            return _appService.ObterPorId(id) != null ? true : false;
        }
    }
}
