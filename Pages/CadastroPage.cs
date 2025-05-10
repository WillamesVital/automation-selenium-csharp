using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomation.Pages
{
    public class CadastroPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string URL = "https://site-practice-automation.vercel.app/cadastro";

        public CadastroPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }


        private IWebElement InputNome => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
        private IWebElement InputEmail => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
        private IWebElement InputSenha => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        private IWebElement InputConfirmarSenha => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirm-password")));
        private IWebElement Telefone => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("phone")));
        private IWebElement DataDeNascimento => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("birthdate")));
        private IWebElement UploadProfilePhoto => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile-photo")));
        private IWebElement UploadResume => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("resume")));
        private IWebElement DropdownPais => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("country")));
        private IWebElement InputLinkPortfolio => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("portfolio")));

        private IWebElement CheckboxAceitarTermos => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("terms")));

        private IWebElement TextObjetivos => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("goals")));

        private IWebElement BotaoCadastrar => _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[type='submit']")));

        public void PreencherFormulario(string nome, string email, string senha, string confirmarSenha, string telefone, string dataDeNascimento, string linkPortfolio, string objetivos)

        {
            InputNome.SendKeys(nome);
            InputEmail.SendKeys(email);
            InputSenha.SendKeys(senha);
            InputConfirmarSenha.SendKeys(confirmarSenha);
            Telefone.SendKeys(telefone);
            DataDeNascimento.SendKeys(dataDeNascimento);
            InputLinkPortfolio.SendKeys(linkPortfolio);
            TextObjetivos.SendKeys(objetivos);

        }

        public void UploadFotoPerfil(string nomeArquivo)
        {
            string caminho = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "TestData",
                "foto.jpg"
            );

            UploadProfilePhoto.SendKeys(caminho);

        }

        public void UploadCurriculo(string nomeArquivo)
        {
            string caminho = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "TestData",
                "resume.pdf"
            );
            UploadResume.SendKeys(caminho);
        }

        public void SelecionarPais(string valorOuTexto)
        {
            var select = new SelectElement(DropdownPais);
            select.SelectByValue(valorOuTexto);
        }

        public void SelecionarGenero(string genero)
        {
            string dataTestId = $"gender-{genero.ToLower()}-checkbox";
            var checkbox = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"input[data-testid='{dataTestId}']")));

            if (!checkbox.Selected)
                checkbox.Click();
        }

        public void SelecionarNivelExperiencia(string nivel)
        {
            string dataTestId = $"experience-{nivel.ToLower()}-radio";
            var radio = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector($"input[data-testid='{dataTestId}']")));

            if (!radio.Selected)
                radio.Click();
        }

        public void AceitarTermos()
        {
            CheckboxAceitarTermos.Click();
        }

        public void ClicarCadastrar()
        {
            BotaoCadastrar.Click();
        }

        public string CapturarAlertaJavascript()
        {
            IAlert alerta = _wait.Until(ExpectedConditions.AlertIsPresent());
            string texto = alerta.Text ?? string.Empty;
            alerta.Accept(); // Fecha o popup
            return texto;
        }

    }
}