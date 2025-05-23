using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumAutomation.Utils
{
    public static class StepHelper
    {
        public static void Step(string stepName, Action action)
        {
            try
            {
                Console.WriteLine($"🟡 Step: {stepName}");
                action.Invoke();
                Console.WriteLine($"✅ Passo concluído: {stepName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Falha no passo: {stepName}");
                throw new Exception($"Erro no passo '{stepName}': {ex.Message}", ex);
            }
        }
    }
}