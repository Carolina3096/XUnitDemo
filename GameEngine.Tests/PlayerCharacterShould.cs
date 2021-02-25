using System;
using Xunit;
using Xunit.Abstractions;
using XUnitDemo;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould:IDisposable
    {
        private readonly PlayerCharacter _playerCharacter;
        private readonly ITestOutputHelper _testOutput;
        public PlayerCharacterShould(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _testOutput.WriteLine("Creating new PlayerCharacter");
            _playerCharacter = new PlayerCharacter();
           
        }
        [Fact]
        public void BeInexpirienceWhenNew()
        {
            
           Assert.True(_playerCharacter.IsNoob);

            //Assert.False(sut.IsNoob);

        }

        [Fact]
        public void CalculateFullName()
        {
            
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            //Assert.Equal("Sarah Smith", sut.FullName);

            Assert.StartsWith("Sarah", _playerCharacter.FullName) ;
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //sut.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.EndsWith("Smith", _playerCharacter.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAsseertExample()
        {
            
            _playerCharacter.FirstName = "SARAH";
            _playerCharacter.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _playerCharacter.FullName, ignoreCase:true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.Contains("ah Sm", _playerCharacter.FullName);
        }

        [Fact]
        public void CalculateFullName_WithTitleCase()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _playerCharacter.FullName);
        }

        //Asserting on Numeric Values 
        //[Fact]
        //public void StartWithDefaultHealth()
        //{
        //    PlayerCharacter sut = new PlayerCharacter();
        //    Assert.Equal(100, sut.he)
        //}

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _playerCharacter.Sleep(); //Expect increase between 1 to 100 inclusive

            Assert.True(_playerCharacter.Health>=1 && _playerCharacter.Health<=200);

            //Assert.InRange(sut.Health, 1, 101);
        }

        //Asserting Null Values 

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_playerCharacter.NickName);
        }

        //Asserting With Collections 
        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _playerCharacter.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", _playerCharacter.Weapons);

        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_playerCharacter.Weapons,weapon=>weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };
            Assert.Equal(expectedWeapons, _playerCharacter.Weapons);
        }

        [Fact]

        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_playerCharacter.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }


        //Assert that events have raised
        [Fact]
        public void RaiseSleptEvent()
        {

            Assert.Raises<EventArgs>(handler => _playerCharacter.PlayerSlept += handler, 
                handler => _playerCharacter.PlayerSlept -= handler,
                () => _playerCharacter.Sleep());

        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_playerCharacter, "Health", () => _playerCharacter.TakeDamage(10));

        }

        //[Fact]
        //public void TakeZeroDamage()
        //{
        //    _playerCharacter.TakeDamage(0);

        //    Assert.Equal(100, _playerCharacter.Health);
        //}

        //[Fact]
        //public void TakeSmallDamage()
        //{
        //    _playerCharacter.TakeDamage(1);

        //    Assert.Equal(99, _playerCharacter.Health);
        //}

        //[Fact]
        //public void TakeMediumDamage()
        //{
        //    _playerCharacter.TakeDamage(50);
        //    Assert.Equal(50, _playerCharacter.Health);
        //}

        //[Fact]
        //public void HaveMinimum1Health()
        //{
        //    _playerCharacter.TakeDamage(101);
        //    Assert.Equal(1, _playerCharacter.Health);
        //}

        //Data Drive TEST with InLine Attribute
        //[Theory]
        //[InlineData(0,100)]
        //[InlineData(1, 99)]
        //[InlineData(50,50)]
        //[InlineData(101,1)]

        //[Theory]
        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        [Theory]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _playerCharacter.TakeDamage(damage);

            Assert.Equal(expectedHealth, _playerCharacter.Health);
        }
        //cleanup code by implementing IDisposable interface
        public void Dispose()
        {
            _testOutput.WriteLine($"Disposing PlayerCharacter {_playerCharacter.FullName}");
        }
    }  
}
