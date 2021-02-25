using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitDemo;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType =typeof(ExternalHealthDamageTestData))]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
