using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _14NET.ProjetoMasterChef.Application.Interfaces;
using _14NET.ProjetoMasterChef.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using _14NET.ProjetoMasterChef.UI.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _14NET.ProjetoMasterChef.UI.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly IReceitaAppService _appService;
        private readonly ICategoriaAppService _categoriaAppService;
        IHostingEnvironment _env;

        public ReceitasController(IReceitaAppService appService, IHostingEnvironment env, ICategoriaAppService categoriaAppService)
        {
            _appService = appService;
            _env = env;
            _categoriaAppService = categoriaAppService;
        }

        // GET: Receitas
        public async Task<IActionResult> Index()
        {
            return View(await _appService.ObterTodos());
        }

        // GET: Receitas/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = _appService.ObterPorId(id.Value);

            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        [Authorize]
        // GET: Receitas/Create
        public IActionResult Create()
        {
            var categorias = _categoriaAppService.ObterTodos().Result.ToList();

            if (categorias.Count() > 0)
            {
                categorias.Insert(0, new CategoriaViewModel { Id = Guid.Empty, Titulo = "Selecione..." });
                ViewBag.CategoriasList = categorias.ToList();
            }
            else
            {
                ViewBag.Error = "Cadastre ao menos uma categoria!";
                return View("ReceitasErrors");
            }

            return View();
        }

        // POST: Receitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(/*[Bind("Id,Titulo,Ingredientes,ModoPreparo,Foto,Tags")]*/ ReceitaViewModel receitaViewModel)
        {
            if (ModelState.ContainsKey("Categoria.Titulo") && ModelState.ContainsKey("Categoria.Descricao"))
            {
                ModelState["Categoria.Titulo"].Errors.Clear();
                ModelState["Categoria.Titulo"].ValidationState = ModelValidationState.Valid;

                ModelState["Categoria.Descricao"].Errors.Clear();
                ModelState["Categoria.Descricao"].ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                receitaViewModel.Id = Guid.NewGuid();

                receitaViewModel = new Helper().SalvarImagem(receitaViewModel, _env.WebRootPath);

                _appService.Adicionar(receitaViewModel);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var categorias = _categoriaAppService.ObterTodos().Result.ToList();

                if (categorias.Count() > 0)
                {
                    categorias.Insert(0, new CategoriaViewModel { Id = Guid.Empty, Titulo = "Selecione..." });
                    ViewBag.CategoriasList = categorias.ToList();
                }
            }

            return View(receitaViewModel);
        }

        // GET: Receitas/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = _appService.ObterPorId(id.Value);

            var categorias = _categoriaAppService.ObterTodos().Result.ToList();

            if (categorias.Count() > 0)
            {
                categorias.Insert(0, new CategoriaViewModel { Id = receita.CategoriaId, Titulo = categorias.Find(x => x.Id == receita.CategoriaId).Titulo });
                categorias.Remove(categorias.FindLast(x => x.Id == receita.CategoriaId));

                ViewBag.CategoriasList = categorias;
            }

            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ReceitaViewModel receitaViewModel)
        {
            if (ModelState.ContainsKey("Categoria.Titulo") && ModelState.ContainsKey("Categoria.Descricao"))
            {
                ModelState["Categoria.Titulo"].Errors.Clear();
                ModelState["Categoria.Titulo"].ValidationState = ModelValidationState.Valid;

                ModelState["Categoria.Descricao"].Errors.Clear();
                ModelState["Categoria.Descricao"].ValidationState = ModelValidationState.Valid;
            }

            if (id != receitaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (receitaViewModel.Foto != null)
                    {
                        if (receitaViewModel.Foto.FileName.Contains(".jpg") || receitaViewModel.Foto.FileName.Contains(".png"))
                        {
                            receitaViewModel = new Helper().SalvarImagem(receitaViewModel, _env.WebRootPath);
                        }
                    }

                    _appService.Atualizar(receitaViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receitaViewModel.Id))
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
            else
            {
                var categorias = _categoriaAppService.ObterTodos().Result.ToList();

                if (categorias.Count() > 0)
                {
                    categorias.Insert(0, new CategoriaViewModel { Id = Guid.Empty, Titulo = "Selecione..." });
                    ViewBag.CategoriasList = categorias.ToList();
                }
            }

            return View(receitaViewModel);
        }

        // GET: Receitas/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = _appService.ObterPorId(id.Value);

            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _appService.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(Guid id)
        {
            return _appService.ObterPorId(id) != null ? true : false;
        }


    }
}
