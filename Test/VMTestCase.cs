using Model;
using ViewModel;

namespace Test
{
    [TestClass]
    public class VMTestCase
    {
        [TestMethod]
        public void MainWindowConstructorTest()
        {
            var window = new MainWindowViewModel();
            var API = ModelAbstractApi.CreateApi();
            Assert.IsNotNull(window);
        }
        [TestMethod]
        public void MainWindowParameterConstructorTest()
        {
            var API = ModelAbstractApi.CreateApi();
            var window = new MainWindowViewModel(API);
            Assert.IsNotNull(window);
        }
    }
}
