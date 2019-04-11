using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Application.ViewModels
{
    public class CreateUpdateReceitaViewModel
    {

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }

        public IFormFile Foto { get; set; }
        public string FotoUrl { get; set; }

        public string Tags { get; set; }

        public virtual CategoriaViewModel Categoria { get; set; }

    }
}
