using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace FutebolDoBairro.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Senha { get; set; } = string.Empty;

        public string Mensagem { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            var usuario = Models.FakeDb.Alunos
                .FirstOrDefault(u => u.Email == Email && u.Senha == Senha);

            if (usuario != null)
            {
                // Login válido, redireciona para Treinos
                return RedirectToPage("/Treinos");
            }
            else
            {
                Mensagem = "Email ou senha inválidos.";
                return Page();
            }
        }
    }
}