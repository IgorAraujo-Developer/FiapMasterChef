using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _14NET.ProjetoMasterChef.Domain.Entities;
using _14NET.ProjetoMasterChef.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;
using _14NET.ProjetoMasterChef.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using _14NET.ProjetoMasterChef.Application.ViewModels;

namespace _14NET.ProjetoMasterChef.UI.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _appService;
        IHostingEnvironment _env;

        public CategoriasController(ICategoriaAppService appService, IHostingEnvironment env)
        {
            _appService = appService;
            _env = env;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _appService.ObterTodos());
        }

        // GET: Categorias/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _appService.ObterPorId(id.Value);

            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,Descricao")] CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                categoriaViewModel.Id = Guid.NewGuid();
                _appService.Adicionar(categoriaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaViewModel);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _appService.ObterPorId(id.Value);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Titulo,Descricao")] CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appService.Atualizar(categoriaViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoriaViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaViewModel);
        }

        // GET: Categorias/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = _appService.ObterPorId(id.Value);
                
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(Guid id)
        {
            return _appService.ObterPorId(id) != null ? true : false;
        }
    }
}
