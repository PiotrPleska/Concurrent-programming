using Model;

namespace ModelTestSuit
{
    [TestClass]
    public class ModelTestCase
    {
        private static TestData data = new TestData();
        private static TestLogic logic = new TestLogic(data);
        ModelAbstractApi API = ModelAbstractApi.CreateApi(logic);

        [TestMethod]
        public void APIConstructorTest()
        {
            ModelAbstractApi api = ModelAbstractApi.CreateApi();
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public void StartTestCase()
        {
            API.Start(1);
            Assert.AreEqual(1, API.GetModelBalls().Count());
        }

        [TestMethod]
        public void SGModelBallsNotNull()
        {
            API.Start(2);
            Assert.IsNotNull(API.GetModelBalls());
        }
    }
}