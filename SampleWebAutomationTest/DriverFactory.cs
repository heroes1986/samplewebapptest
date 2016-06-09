using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;

namespace SampleWebAutomationTest
{
    public enum DriverType
    {
        PhantomJs = 0,
        Chrome
    }

    public interface IDriverFactory
    {
        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IWebDriver GetDriver(DriverType type);
    }
    public class DriverFactory : IDriverFactory
    {
        private static IDriverFactory _instance;
        public static IDriverFactory Instance
        {
            get { return _instance ?? (_instance = new DriverFactory()); }
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IWebDriver GetDriver(DriverType type)
        {
            switch (type)
            {
                case DriverType.PhantomJs:
                {
                    var service = PhantomJSDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = true;
                    return new PhantomJSDriver(service);
                }
                case DriverType.Chrome:
                {
                    var service = ChromeDriverService.CreateDefaultService();
                    service.HideCommandPromptWindow = true;
                    return new ChromeDriver(service);
                }
                default:
                    return null;
            }
        }
    }
}
