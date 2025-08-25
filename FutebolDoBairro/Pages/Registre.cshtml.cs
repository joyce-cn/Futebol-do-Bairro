using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FutebolDoBairro.Models;

namespace FutebolDoBairro.Pages
{
    public class RegistreModel : PageModel
    {
        [BindProperty]
        public CadastroModel Cadastro { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // FakeDB ou envio de email
            Models.FakeDb.Alunos.Add(Cadastro);

            return RedirectToPage("/Treinos");
        }
    }
}