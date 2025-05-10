using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Pages;

namespace SeleniumAutomation.Tests
{
    public class HomePageTests
    {
        private IWebDriver driver;
        private HomePage homePage;

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
            homePage.Load();
        }

        [Test]
        public void DeveExibirOTituloCorretoNaHomePage()
        {
            string titulo = homePage.GetTitlePage();
            Assert.That(titulo, Is.EqualTo("Curso Prático de Automação de Testes com Playwright"));
        }

        [Test]
        public void DeveNavegarParaPaginaDeLogin()
        {
            homePage.ClicarEmLogin();
            Assert.That(driver.Url, Does.Contain("login"));
            Assert.That(driver.Title, Is.EqualTo("Login"));
        }

        [Test]
        public void DeveNavegarParaPaginaDeCadastro()
        {
            homePage.ClicarEmCadastro();
            Assert.That(driver.Url, Does.Contain("register"));
            Assert.That(driver.Title, Is.EqualTo("Cadastro de Usuário"));
        }

        [Test]
        public void DeveNavegarParaPaginaDePesquisa()
        {
            homePage.ClicarEmPesquisa();
            Assert.That(driver.Url, Does.Contain("search"));
            Assert.That(driver.Title, Is.EqualTo("Pesquisa na Web - Google"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
