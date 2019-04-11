using System;
using System.Collections.Generic;
using System.Text;

namespace _14NET.ProjetoMasterChef.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
