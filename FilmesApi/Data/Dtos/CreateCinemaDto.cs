using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateCinemaDto
    {
        public int id { get; set; }
        public string Nome { get; set; }

        public int EnderecoId { get; set; }

    }
}
