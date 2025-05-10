using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumAutomation.Pages
{
    public class HomePage

    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string URL = "https://site-practice-automation.vercel.app/";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Elements
        private IWebElement TitlePage => _wait.Until(
            ExpectedConditions.ElementIsVisible(By.XPath("//h1[@data-testid='course-title']"))
        );
        private IWebElement BtnLogin => _wait.Until(
            ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Login']"))
        );
        private IWebElement BtnCadastro => _wait.Until(
            ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Cadastre-se']"))
        );
        private IWebElement BtnPesquisa => _wait.Until(
            ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Pesquisa']"))
        );

        public void GoTo()
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public void Load()
        {
            GoTo();
            WaitForElementToBeVisible(By.XPath("//h1[@data-testid='course-title']"));
        }

        public string GetTitlePage() => TitlePage.Text;
        public void ClicarEmLogin() => BtnLogin.Click();
        public void ClicarEmCadastro() => BtnCadastro.Click();
        public void ClicarEmPesquisa() => BtnPesquisa.Click();

        public void WaitForElementToBeVisible(By by)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
