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
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaAppService _appService;
        private readonly ICategoriaAppService _categoriaAppService;

        public ReceitasController(IReceitaAppService appService, ICategoriaAppService categoriaAppService)
        {
            _appService = appService;
            _categoriaAppService = categoriaAppService;
        }

        // GET: api/Receitas
        [HttpGet]
        public ActionResult<IEnumerable<ReceitaViewModel>> GetReceitas()
        {
            return _appService.ObterTodos().Result.ToList();            
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public ActionResult<ReceitaViewModel> GetReceita(Guid id)
        {
            var receita = _appService.ObterPorId(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // POST: api/Receitas
        [HttpPost]
        public ActionResult<ReceitaViewModel> PostReceita(ReceitaViewModel receita)
        {
            _appService.Adicionar(receita);           

            return CreatedAtAction("GetReceita", new { id = receita.Id }, receita);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public ActionResult<ReceitaViewModel> DeleteReceita(Guid id)
        {
            var receita = _appService.ObterPorId(id);

            if (receita == null)
            {
                return NotFound();
            }

            _appService.Remover(id);           

            return receita;
        }

        [HttpPut("{id}")]
        public ActionResult<ReceitaViewModel> PutReceita(int id, [FromBody]ReceitaViewModel receita)
        {
            _appService.Atualizar(receita);            

            return Ok(receita);
        }

        private bool ReceitaExists(Guid id)
        {
            return _appService.ObterPorId(id) != null ? true : false;
        }
    }
}
