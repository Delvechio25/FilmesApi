﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
        
        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O titulo do gênero é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero não pode execer 50 caracteres")]
        public string Genero { get; set; }
        [Required]
        //[Range(70,600, ErrorMessage ="A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
