using System;
using NUnit.Framework;
using LeaveTheHouseApp;

namespace LeaveTheHouseAppTest
{
    [TestFixture]
    public class CommandFactoryTests
    {
        [TestCase(0)]
        [TestCase(9)]
        [TestCase(999)]
        [TestCase(-1)]
        public void CreateInvalidCommandTest(int id)
        {
            // arrange
            UserState state = new UserState();
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);

            // act
            Command command = CommandFactory.CreateCommand(receiver, id);

            // assert
            Assert.IsNull(command);
        }

        [TestCase(1, typeof(PutOnFootwearCommand))]
        [TestCase(2, typeof(PutOnHeadwearCommand))]
        [TestCase(3, typeof(PutOnSocksCommand))]
        [TestCase(4, typeof(PutOnShirtCommand))]
        [TestCase(5, typeof(PutOnJacketCommand))]
        [TestCase(6, typeof(PutOnPantsCommand))]
        [TestCase(7, typeof(LeaveHouseCommand))]
        [TestCase(8, typeof(TakeOffPajamasCommand))]
        public void CreateCommandTests(int id, Type expected)
        {
            // arrange
            UserState state = new UserState();
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            
            // act
            Command command = CommandFactory.CreateCommand(receiver, id);

            // assert
            Assert.AreEqual(expected, command.GetType());
        }
    }
}