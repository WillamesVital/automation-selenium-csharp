using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Pages;
using System;

namespace SeleniumAutomation.Tests
{
    public class CadastroTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private CadastroPage cadastroPage;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();

            // Verifica se estamos em ambiente de CI (GitHub Actions)
            var isCI = Environment.GetEnvironmentVariable("CI") == "true";

            if (isCI)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
            }

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            homePage = new HomePage(driver);
            cadastroPage = new CadastroPage(driver);
            homePage.Load();
        }

        [Test]
        public void DevePreencherFormularioCadastro()
        {
            homePage.ClicarEmCadastro();
            cadastroPage.PreencherFormulario(
                "Teste Nome",
                "test@test.com",
                "Senha123",
                "Senha123",
                "1234567890",
                "01/01/2000",
                "https://github.com/WillamesVital",
                "Aprender automação de testes com Selenium e C#"
            );

            cadastroPage.UploadFotoPerfil("foto.jpg");

            cadastroPage.UploadCurriculo("resume.pdf");

            cadastroPage.SelecionarPais("brasil");

            cadastroPage.SelecionarGenero("masculino");

            cadastroPage.SelecionarNivelExperiencia("intermediario");

            cadastroPage.AceitarTermos();

            cadastroPage.ClicarCadastrar();
            

            string mensagem = cadastroPage.CapturarAlertaJavascript();
            Assert.That(mensagem, Is.EqualTo("Cadastro realizado com sucesso!"));

        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}