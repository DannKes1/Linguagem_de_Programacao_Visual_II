# Projeto Exemplo: ASP.NET Core MVC com Padrão ViewModel

Este é um projeto de exemplo construído com **ASP.NET Core MVC** para demonstrar a aplicação do padrão **Model-ViewModel (MVVM)**, mantendo os Controllers limpos e delegando a lógica de formatação de dados para **Extension Methods**.

A aplicação gerencia uma lista de produtos com funcionalidades de listagem (com filtros e ordenação) e uma página de detalhes para cada produto, utilizando dados mockados em memória.

---

## 🎯 Objetivo do Projeto

O objetivo principal é demonstrar uma arquitetura limpa e de fácil manutenção em ASP.NET Core MVC, onde as responsabilidades são claramente separadas:

- **Model**: Representa os dados brutos da aplicação (a entidade Produto).  
- **ViewModel**: Modela os dados especificamente para uma View, contendo apenas as propriedades e os formatos necessários para a exibição.  
- **Extension Methods**: Centralizam toda a lógica de conversão e formatação de dados (ex: formatação de moeda, conversão de booleanos para texto), desacoplando-a dos Models e Controllers.  
- **Controller**: Atua como um orquestrador, recebendo requisições, buscando dados, aplicando filtros/ordenação e delegando a conversão para os Extension Methods antes de passar o ViewModel para a View.  
- **View**: É responsável unicamente pela apresentação dos dados contidos no ViewModel.  

---

## 🚀 Tecnologias Utilizadas

- .NET 8  
- ASP.NET Core MVC  
- C# 12  
- Bootstrap 5 (padrão do template MVC)  

---

## ✨ Conceitos Chave Implementados

### 1. Padrão Model-ViewModel
- **Produto.cs (Model)**: Contém as propriedades puras do domínio, como `Id`, `Nome`, `Preco`, e uma propriedade calculada `DiasNoSistema`. Não possui nenhuma lógica de formatação.  
- **ProdutoListagemItemViewModel.cs**: Shape de dados para cada linha da tabela de listagem. Inclui propriedades formatadas como `PrecoFormatado` (R$ 1.299,99), `Status` ("Ativo"/"Inativo") e `Badge` ("Premium").  
- **ProdutoDetalhesViewModel.cs**: Shape de dados para a página de detalhes. Contém dados formatados como `CategoriaExibicao` ("Categoria: Eletrônicos"), `TempoNoSistema` ("N dias no sistema") e uma lista de produtos relacionados.  

### 2. Controllers Limpos
O **ProdutoController.cs** não contém código de formatação de strings, concatenação ou lógica de UI. Suas responsabilidades são:  
- Gerenciar os dados mockados.  
- Aplicar filtros de categoria.  
- Aplicar regras de ordenação.  
- Chamar os Extension Methods para mapear o Model para o ViewModel apropriado.  

### 3. Extension Methods para Mapeamento
A classe estática **ProdutoExtensions.cs** contém os métodos `ToListItemViewModel()` e `ToDetalhesViewModel()`.  

Toda a lógica de formatação está aqui. Isso torna o código reutilizável e centralizado. Se a regra de formatação de moeda mudar, por exemplo, a alteração é feita em um único lugar.  

### 4. Dados Mock em Memória
Para simplificar a execução e focar na arquitetura, o projeto utiliza uma lista estática (`List<Produto>`) como fonte de dados. Não há necessidade de configurar um banco de dados.  

---

## 🔧 Como Executar o Projeto

### Pré-requisitos
- .NET 8 SDK  
- Um editor de código como **JetBrains Rider**, **Visual Studio 2022** ou **Visual Studio Code**.  

### Passos

**Clone o repositório:**
```bash
git clone https://github.com/DannKes1/Linguagem_de_Programacao_Visual_II.git
cd Linguagem_de_Programacao_Visual_II
