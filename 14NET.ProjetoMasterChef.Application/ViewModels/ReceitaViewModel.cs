using _14NET.ProjetoMasterChef.Application.DataAnnotationExtension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace _14NET.ProjetoMasterChef.Application.ViewModels
{
    public class ReceitaViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [MaxLength(100,ErrorMessage = "Máximo de 100 caracteres excedido.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="Ingrediente é obrigatório")]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "Modo de Preparo é obrigatório")]
        [Display(Name = "Modo de Preparo")]
        public string ModoPreparo { get; set; }

        [FileTypes("jpg,jpeg,png")]
        [Required(ErrorMessage = "É obrigatório anexar uma imagem.")]
        public IFormFile Foto { get; set; }
        public string FotoURL { get; set; }
        public string Tags { get; set; }

        public CategoriaViewModel Categoria { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
