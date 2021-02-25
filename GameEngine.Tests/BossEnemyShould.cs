using System;
using Xunit;
using XUnitDemo;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _testOutput;
        public BossEnemyShould(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }
        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower()
        {
            _testOutput.WriteLine("Create Boss Enemy");
            BossEnemy sut = new BossEnemy();
            Assert.Equal(166.667, sut.SpecialAttackPower, 3);

        }
    }
}
