using System.ComponentModel.DataAnnotations;

namespace HospitalCrud.Entity
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O NomeCompleto é obrigatório.")]
        public string NomeCompleto { get; set; }

        public string FotoBase64 { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O NumeroCelular é obrigatório.")]
        public string NumeroCelular { get; set; }

        [Required(ErrorMessage = "O Endereco é obrigatório.")]
        public string Endereco { get; set; }
    }
}
