using Model;

namespace Test
{
    [TestClass]
    public class ModelLayerTestCase
    {
        ModelAbstractApi API = ModelAbstractApi.CreateApi();

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
