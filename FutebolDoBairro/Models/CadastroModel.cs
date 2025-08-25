using System.ComponentModel.DataAnnotations;


namespace FutebolDoBairro.Models
{
    public class CadastroModel
    {
        [Required(ErrorMessage = "O nome do responsável é obrigatório")]
        public string NomeResponsavel { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        public string NomeAluno { get; set; } = string.Empty;

        [Required(ErrorMessage = "A idade é obrigatória")]
        [Range(6, 16, ErrorMessage = "A idade deve estar entre 6 e 16 anos")]
        public int IdadeAluno { get; set; }

        [Required(ErrorMessage = "A posição é obrigatória")]
        public string Posicao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
