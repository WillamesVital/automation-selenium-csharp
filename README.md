# Projeto de Testes Automatizados com Selenium e C\#

Este repositório contém uma automação de testes end-to-end utilizando **Selenium WebDriver com C# e NUnit**, aplicada sobre o site de prática: [https://site-practice-automation.vercel.app](https://site-practice-automation.vercel.app).

## 📊 Visão Geral

O projeto é estruturado com o padrão **Page Object Model (POM)** e tem como foco a manutenção, legibilidade e expansão dos testes de forma escalável.

Foram implementados testes para validar:

* A tela inicial (Home)
* O fluxo completo de cadastro
* Upload de arquivos
* Interações com dropdowns, checkboxes e radios
* Validações de alertas de sucesso e erro (positivos e negativos)

---

## 🛁 Estrutura do Projeto

```
automation-selenium-csharp/
├── Pages/                  # Page Objects (HomePage, CadastroPage)
├── Tests/                  # Testes NUnit (HomePageTests, CadastroTests)
├── TestData/               # Arquivos utilizados nos testes (foto.jpg, resume.pdf)
├── .github/workflows/      # Pipeline do GitHub Actions
├── automation-selenium-csharp.csproj
└── README.md
```

---

## ✅ Requisitos

* [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
* [Chrome](https://www.google.com/chrome/) instalado
* Visual Studio Code

---

## 🔧 Como executar o projeto localmente

1. **Clone o repositório:**

```bash
git clone https://github.com/seu-usuario/automation-selenium-csharp.git
cd automation-selenium-csharp
```

2. **Restaure os pacotes:**

```bash
dotnet restore
```

3. **Build do projeto:**

```bash
dotnet build
```

4. **Execute todos os testes:**

```bash
dotnet test
```

5. **Execute um teste específico:**

```bash
dotnet test --filter "Name=DevePreencherFormularioCadastro"
```

> ⚡ Use `CI=true` para rodar em headless mode:

```bash
CI=true dotnet test
```

---

## 🪨 Testes Implementados

### HomePageTests

* Verifica o título da página
* Navegação correta para Login, Cadastro e Pesquisa

### CadastroTests (Fluxo positivo)

* Preenchimento completo do formulário
* Upload de imagem e PDF
* Seleção de gênero, país e nível de experiência
* Aceite de termos
* Submissão e validação de alerta de sucesso

---

## 🌎 Integração Contínua com GitHub Actions

O repositório está configurado para executar os testes automaticamente a cada `push` ou `pull request` via workflow em:

```
.github/workflows/ci.yml
```

Inclui:

* Execução em ambiente Linux
* Chrome headless via imagem Selenium
* Upload de screenshots e logs (em breve)

---

## 🎯 Futuras melhorias

* Geração de relatórios HTML (Allure, ExtentReports ou ReportUnit)
* Testes parametrizados
* Integração com BrowserStack / Sauce Labs
* Implementação de logs e screenshots em falhas

---

## 👨‍💻 Autor

**Willames Vital**
Engenheiro de Qualidade | Especialista em Testes Automatizados com C# e Playwright

---

> ✨ Contribuições são bem-vindas! Forka o projeto, cria uma branch, envia seu PR :)
