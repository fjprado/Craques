using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Craques.Models
{
    public class CraqueDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username é de preenchimento obrigatório.")]
        [StringLength(20, ErrorMessage = "Username pode ter no mínimo 2 e no máximo 20 caracteres.", MinimumLength = 2)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Posição é de preenchimento obrigatório.")]
        public string Posicao { get; set; }
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage = "Nível de ataque é de preenchimento obrigatório.")]
        [Range(1, 10, ErrorMessage = "O intervalo para nível de ataque deve ser de 1 a 10.")]
        public int NivelAtaque { get; set; }
        [Required(ErrorMessage = "Nível de defesa é de preenchimento obrigatório.")]
        [Range(1, 10, ErrorMessage = "O intervalo para nível de defesa deve ser de 1 a 10.")]
        public int NivelDefesa { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Email é de preenchimento obrigatório.")]
        [RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/", ErrorMessage = "O email não está em um formato válido.")]
        public string Email { get; set; }   
    }
}