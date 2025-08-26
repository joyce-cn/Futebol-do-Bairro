⚽ Futebol do Bairro

Plataforma simples desenvolvida em ASP.NET Core com Razor Pages para ajudar no recrutamento de meninos de 6 a 16 anos para um projeto de futebol comunitário.

🚀 Funcionalidades

Cadastro de responsável e criança

Definição da posição do jogador

Validação de idade entre 6 e 16 anos

Página de inscrição com campos obrigatórios

Estrutura preparada para evoluir futuramente com:

Agendamento de treinos

Datas de jogos e campeonatos

Envio de lembretes por e-mail

🛠️ Tecnologias Utilizadas

C#

ASP.NET Core 9.0

Razor Pages

(mock para banco de dados no momento — preparado para futura integração com SQL Server)

📂 Estrutura do Projeto

Pages/Registre.cshtml → Página de cadastro do responsável e da criança

Models/CadastroModel.cs → Estrutura de dados do cadastro

Program.cs → Configuração principal da aplicação

▶️ Como Rodar Localmente

Clone o repositório:

git clone https://github.com/joyce-cn/Futebol-do-Bairro.git


Acesse a pasta:

cd Futebol-do-Bairro


Rode o projeto:

dotnet run


Abra no navegador:

https://localhost:5247/Registre

📌 Próximos Passos

Integração com banco de dados SQL Server

Sistema de login e autenticação

Notificações automáticas de treinos e jogos

Dashboard para responsáveis acompanharem os eventos

🤝 Contribuição

Fique à vontade para abrir issues ou enviar pull requests.
Esse projeto é voltado para aprendizado e evolução prática em C#.
