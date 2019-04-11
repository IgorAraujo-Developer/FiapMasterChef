using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Domain.Entities
{
    public class Receita
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string FotoUrl { get; set; }
        public string Tags { get; set; }

        public virtual Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
