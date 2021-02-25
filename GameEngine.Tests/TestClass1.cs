using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using XUnitDemo;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass1
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _outputHelper;

        public TestClass1(GameStateFixture gameStateFixture, ITestOutputHelper outputHelper)
        {
            _gameStateFixture = gameStateFixture;
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Test1()
        {
            _outputHelper.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test2()
        {
            _outputHelper.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
    }
}
