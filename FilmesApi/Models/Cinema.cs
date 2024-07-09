using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string Nome  { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; } // explicitando para o entity que tem uma relação 1:1 com o modelo de Endereco
    }
}
