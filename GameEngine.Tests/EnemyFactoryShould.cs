using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitDemo;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact] 
       
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy=sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy);

        }

        [Fact]
        public void CreateNormalEnemyByDefault_ByTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy);
        }
       
        [Fact(Skip ="Don't need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsNotType<DateTime>(enemy);
        }
    }
}
