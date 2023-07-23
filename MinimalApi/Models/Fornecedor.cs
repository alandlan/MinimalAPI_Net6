using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string? Nome { get; set; }
        [Required, MinLength(11), MaxLength(14)]
        public string? Documento { get; set; }
        public bool Ativo { get; set; }
    }
}