Sistema de Gerenciamento de Produtos (Exercício MVC)
Este projeto foi desenvolvido como um exercício prático para demonstrar os diferentes tipos de ActionResult disponíveis no framework ASP.NET Core MVC. A aplicação simula um sistema simples de gerenciamento de produtos para uma loja.

🎯 Objetivo
O objetivo principal é criar uma aplicação MVC que demonstre o uso dos três principais tipos de Actions:

ViewResult: Para renderizar interfaces HTML do lado do servidor.

JsonResult: Para expor dados em formato JSON, ideal para APIs e requisições AJAX.

FileResult: Para gerar e disponibilizar arquivos para download.

✨ Funcionalidades

Listagem de Produtos: Exibe todos os produtos cadastrados em uma tabela na página inicial.


Detalhes do Produto: Mostra todas as informações de um produto específico.


Filtro por Categoria: Permite filtrar os produtos exibidos com base em sua categoria.


Consulta de Dados via AJAX: Um botão na página inicial busca e exibe a lista completa de produtos em formato JSON sem recarregar a página.

Exportação de Dados:


CSV: Gera e baixa um arquivo .csv com a lista de produtos.


Relatório TXT: Gera um relatório de texto (.txt) com estatísticas sobre o catálogo (total de itens, contagem por categoria, etc.).


JSON: Permite o download de um arquivo .json contendo todos os dados dos produtos.

⚙️ Tecnologias Utilizadas
Backend: C# 12, ASP.NET Core MVC 8.0

Frontend: HTML, CSS, JavaScript, Bootstrap

Framework: .NET 8.0

IDE: JetBrains Rider

🚀 Como Executar o Projeto
Para executar este projeto localmente, siga os passos abaixo:

Pré-requisitos:

Ter o .NET 8 SDK instalado.

Ter o Git instalado.

Clonar o repositório:

Bash

git clone https://github.com/seu-usuario/GerenciamentoProdutos.git
Navegar para a pasta do projeto:

Bash

cd GerenciamentoProdutos
Executar a aplicação:

Via linha de comando:

Bash

dotnet run
Via Rider ou Visual Studio:
Abra o arquivo da solução (.sln) e clique no botão de "Play" (▶️) para iniciar o projeto.

Acessar no navegador:
Abra seu navegador e acesse o endereço fornecido no console (geralmente http://localhost:5000 ou https://localhost:5001).

📂 Estrutura do Projeto
O projeto segue a estrutura padrão do padrão arquitetural Model-View-Controller:


Models/Produto.cs: Define a estrutura de dados do produto.


Controllers/ProdutoController.cs: Contém toda a lógica de negócio, incluindo as actions ViewResult, JsonResult e FileResult.


Views/Produto/: Contém os arquivos .cshtml responsáveis por renderizar a interface do usuário para cada action ViewResult (Index.cshtml , 

Detalhes.cshtml , 

Categoria.cshtml ).

wwwroot: Contém os arquivos estáticos como CSS, JavaScript e bibliotecas.
