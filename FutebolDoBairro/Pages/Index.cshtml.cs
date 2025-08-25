using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FutebolDoBairro.Models;
using System.Collections.Generic;

namespace FutebolDoBairro.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CadastroModel Cadastro { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Volta para o formulário se houver erro de validação
            }

            // Aqui você pode salvar o cadastro no banco, se desejar

            Console.WriteLine($"Responsável: {Cadastro.NomeResponsavel}, Filho: {Cadastro.NomeAluno}");

            var emailService = new Email(
                "smtp.gmail.com",
                "desouzacunhajoyce@gmail.com",
                "ligc cfml mrni dxmy" // Sua senha de app do Gmail
            );

            string assunto = "Confirmação de Inscrição - Futebol do Bairro";
            string corpo = $@"
                <h2>Caro(a) {Cadastro.NomeResponsavel},</h2>
                <p>Seu cadastro foi realizado com sucesso no projeto <b>Futebol do Bairro</b>!</p>
                <p><b>Datas dos treinos:</b> Toda terça e quinta às 18h.</p>
                <p><b>Próximo jogo:</b> 20/08 às 15h.</p>
                <p><b>Campeonatos futuros:</b> Copa do Bairro - Setembro.</p>
                <p>Obrigado por participar!</p>
            ";

            emailService.SendEmail(
                new List<string> { Cadastro.Email },
                assunto,
                corpo,
                null
            );

            TempData["Mensagem"] = "Cadastro recebido com sucesso!";

            return RedirectToPage("/Confirmacao");
        }
    }
}
