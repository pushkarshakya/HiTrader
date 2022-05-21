using HiTrader.WebApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HiTrader.WebAPi.UnitTests
{
    public class RewardControllerTest
    {
        private readonly Mock<ILogger<RewardController>> _loggerMock = new Mock<ILogger<RewardController>>();

        [Fact]
        public void Get_Should_ReturnZeroWhenZeroPurchase()
        {
            RewardController controller = new RewardController(_loggerMock.Object);

            int reward = controller.Get(0M);

            Assert.Equal(0, reward);
        }

        [Theory]
        [InlineData(49.5)]
        [InlineData(50.9)]
        public void Get_Should_ReturnZeroWhenPurchaseLessThanOrEqual51(decimal purchase)
        {
            RewardController controller = new RewardController(_loggerMock.Object);

            int reward = controller.Get(purchase);

            Assert.Equal(0, reward);
        }

        [Theory]
        [InlineData(51.00)]
        [InlineData(53.82)]
        [InlineData(100.87)]
        public void Get_Should_ReturnBasicRewardWhenPurchaseGreaterThanOrEqual51AndLessThan101(decimal purchase)
        {
            RewardController controller = new RewardController(_loggerMock.Object);

            int reward = controller.Get(purchase);

            Assert.Equal((int)purchase - 50, reward);
        }

        [Theory]
        [InlineData(101.00)]
        [InlineData(356.55)]
        public void Get_Should_ReturnExtraRewardWhenPurchaseGreaterThanOrEqual101(decimal purchase)
        {
            RewardController controller = new RewardController(_loggerMock.Object);

            int reward = controller.Get(purchase);


            Assert.Equal((int)purchase - 50 + (int)purchase - 100, reward);
        }
    }
}
