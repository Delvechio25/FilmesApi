﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadCinemaDto
    {
        
        public int id { get; set; }
        public string Nome { get; set; }

        public ReadEnderecoDto ReadEnderecoDto { get; set; }

    }
}
