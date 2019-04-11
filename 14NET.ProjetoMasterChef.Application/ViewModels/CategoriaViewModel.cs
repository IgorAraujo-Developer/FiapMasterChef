using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _14NET.ProjetoMasterChef.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [Display(Name = "Título")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres excedido.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo de 255 caracteres excedido.")]
        public string Descricao { get; set; }
    }
}
