using HiTrader.WebApi.Controllers;
using System;
using Xunit;

namespace HiTrader.WebAPi.UnitTests
{
    public class RewardControllerTest
    {
        [Fact]
        public void Get_Should_ReturnZeroWhenZeroPurchase()
        {
            RewardController controller = new RewardController();

            int reward=controller.Get(0M);

            Assert.Equal(0, reward);
        }
    }
}
