using NUnit.Framework;
using OpenQA.Selenium;

namespace SampleWebAutomationTest
{
    [TestFixture(DriverType.PhantomJs)]
    //[TestFixture(DriverType.Chrome)]
    public class LandingPageTests
    {
        private IWebDriver _driver;
        private readonly DriverType _type;

        public LandingPageTests(DriverType type)
        {
            _type = type;
        }

        [TestFixtureSetUp]
        public void OneTimeSetup()
        {
            _driver = DriverFactory.Instance.GetDriver(_type);
        }

        [TestFixtureTearDown]
        public void OneTimeTearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("http://test.sampleapp.com/");
        }

        [TestCase("about")]
        public void About_Navigation_Found_Return_Ok(string id)
        {
            // Arrange


            // Act
            var result = _driver.FindElement(By.Id(id));

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase("about")]
        public void About_Navigation_To_About_Page_Return_Ok(string id)
        {
            // Arrange
            var expectedUrl = "http://test.sampleapp.com/Home/About";

            var element = _driver.FindElement(By.Id(id));
            var url = element.GetAttribute("href");
           
            // Act
            _driver.Navigate().GoToUrl(url);

            // Assert
            Assert.IsNotNullOrEmpty(url);
            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        [TestCase("contact")]
        public void Contact_Navigation_Found_Return_Ok(string id)
        {
            // Arrange


            // Act
            var result = _driver.FindElement(By.Id(id));

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase("contact")]
        public void Contact_Navigation_To_Contact_Page_Return_Ok(string id)
        {
            // Arrange
            var expectedUrl = "http://test.sampleapp.com/Home/Contact";

            var element = _driver.FindElement(By.Id(id));
            var url = element.GetAttribute("href");

            // Act
            _driver.Navigate().GoToUrl(url);

            // Assert
            Assert.IsNotNullOrEmpty(url);
            Assert.AreEqual(expectedUrl, _driver.Url);
        }
    }
}
