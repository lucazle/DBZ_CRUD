using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDBZ.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "O nome do personagem é obrigatório.")]
        [MaxLength (50, ErrorMessage = "O nome do personagem não pode exceder 50 caracteres.")]
        [MinLength (2, ErrorMessage = "O nome do personagem deve conter pelo menos 2 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo do personagem é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O tipo do personagem não pode exceder 50 caracteres.")]
        [MinLength(2, ErrorMessage = "O tipo do personagem deve conter pelo menos 2 caracteres.")]
        public string Tipo { get; set; }

    }
}
