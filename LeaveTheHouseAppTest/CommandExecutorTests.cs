using System;
using NUnit.Framework;
using LeaveTheHouseApp;

namespace LeaveTheHouseAppTest
{
    [TestFixture]
    public class CommandExecutorTests
    {
        [Test]
        public void InitialStateTest()
        {
            UserState state = new UserState();

            Assert.IsTrue(state.PajamasOn);
            Assert.IsFalse(state.LeftHouse);
        }
        
        [TestCase(ActionItems.PutOnFootwear)]
        [TestCase(ActionItems.PutOnHeadwear)]
        [TestCase(ActionItems.PutOnJacket)]
        [TestCase(ActionItems.PutOnPants)]
        [TestCase(ActionItems.PutOnShirt)]
        [TestCase(ActionItems.PutOnSocks)]
        public void PajamasMustBeTakenOffBeforeAnythingElseCanBePutOnTest(ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState();
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);            
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, true, false, false, false, false, false, false, ActionItems.PutOnFootwear)]
        [TestCase(false, false, true, false, false, false, false, false, ActionItems.PutOnHeadwear)]
        [TestCase(false, false, false, true, false, false, false, false, ActionItems.PutOnSocks)]
        [TestCase(false, false, false, false, true, false, false, false, ActionItems.PutOnShirt)]
        [TestCase(false, false, false, false, false, true, false, false, ActionItems.PutOnJacket)]
        [TestCase(false, false, false, false, false, false, true, false, ActionItems.PutOnPants)]
        public void OnlyOnePieceofEachTypeOfClothingMayBePutOnTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, false, false, false, false, false, ActionItems.PutOnSocks)]
        public void YouCannotPutOnSocksWhenItIsHotTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, false, false, false, false, false, ActionItems.PutOnJacket)]
        public void YouCannotPutOnJacketWhenItIsHotTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, true, false, false, true, false, ActionItems.PutOnFootwear)]
        public void SocksMustBePutOnBeforeShoesSuccessTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.COLD;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsTrue(result);
        }

        [TestCase(false, false, false, false, false, false, true, false, ActionItems.PutOnFootwear)]
        public void SocksMustBePutOnBeforeShoesFailureTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.COLD;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, false, false, false, true, false, ActionItems.PutOnFootwear)]
        public void PantsMustBePutOnBeforeShoesSuccessTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsTrue(result);
        }

        [TestCase(false, false, false, false, false, false, false, false, ActionItems.PutOnFootwear)]
        public void PantsMustBePutOnBeforeShoesFailureTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, false, false, false, false, false, ActionItems.PutOnShirt)]
        public void ShirtMustBePutOnBeforeTheHeadwearOrJacketSuccessTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsTrue(result);
        }

        [TestCase(false, false, true, false, false, false, false, false, ActionItems.PutOnShirt)]
        public void ShirtMustBePutOnBeforeTheHeadwearOrJacketFailureOnHeadwearTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, false, false, false, true, false, false, false, ActionItems.PutOnShirt)]
        public void ShirtMustBePutOnBeforeTheHeadwearOrJacketFailureOnJacketTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.COLD;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }

        [TestCase(false, true, true, false, true, false, true, false, ActionItems.LeaveHouse)] // all but jacket or socks
        public void YouCannotLeaveTheHouseUntilAllItemsOfClothingAreOnInHOTWeatherSuccessTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsTrue(result);
        }

        [TestCase(false, true, true, true, true, true, true, false, ActionItems.LeaveHouse)] // all on
        public void YouCannotLeaveTheHouseUntilAllItemsOfClothingAreOnInCOLDWeatherSuccessTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.COLD;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsTrue(result);
        }

        [TestCase(false, true, false, false, false, false, false, false, ActionItems.LeaveHouse)] // footwear only
        [TestCase(false, true, true, false, false, false, false, false, ActionItems.LeaveHouse)] // footwear and headwear only
        [TestCase(false, true, true, true, false, false, false, false, ActionItems.LeaveHouse)] // footwear, headwear, and socks only
        [TestCase(false, true, true, true, true, false, false, false, ActionItems.LeaveHouse)] // footwear, headwear, socks, and shirt only (no jacket or pants)
        [TestCase(false, true, true, true, true, true, false, false, ActionItems.LeaveHouse)] // // footwear, headwear, socks, shirt, and jacket only (no pants)
        [TestCase(false, false, true, true, true, true, true, false, ActionItems.LeaveHouse)] // no footwear
        [TestCase(false, true, false, true, true, true, true, false, ActionItems.LeaveHouse)] // no headwear
        [TestCase(false, true, true, true, false, true, true, false, ActionItems.LeaveHouse)] // no shirt
        public void YouCannotLeaveTheHouseUntilAllItemsOfClothingAreOnInHOTWeatherFailureTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.HOT;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }
        
        [TestCase(false, true, false, false, false, false, false, false, ActionItems.LeaveHouse)] // footwear only
        [TestCase(false, true, true, false, false, false, false, false, ActionItems.LeaveHouse)] // footwear and headwear only
        [TestCase(false, true, true, true, false, false, false, false, ActionItems.LeaveHouse)] // footwear, headwear, and socks only
        [TestCase(false, true, true, true, true, false, false, false, ActionItems.LeaveHouse)] // footwear, headwear, socks, and shirt only (no jacket or pants)
        [TestCase(false, true, true, true, true, true, false, false, ActionItems.LeaveHouse)] // // footwear, headwear, socks, shirt, and jacket only (no pants)
        [TestCase(false, true, true, false, true, false, true, false, ActionItems.LeaveHouse)] // no jacket or socks
        [TestCase(false, false, true, true, true, true, true, false, ActionItems.LeaveHouse)] // no footwear
        [TestCase(false, true, false, true, true, true, true, false, ActionItems.LeaveHouse)] // no headwear
        [TestCase(false, true, true, false, true, true, true, false, ActionItems.LeaveHouse)] // no socks
        [TestCase(false, true, true, true, false, true, true, false, ActionItems.LeaveHouse)] // no shirt
        [TestCase(false, true, true, true, true, false, true, false, ActionItems.LeaveHouse)] // no jacket
        public void YouCannotLeaveTheHouseUntilAllItemsOfClothingAreOnInCOLDWeatherFailureTest(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse, ActionItems actionItem)
        {
            // arrange
            UserState state = new UserState(pajamasOn, footwearOn, headwearOn, socksOn, shirtOn, jacketOn, pantsOn, leftHouse);
            Weather weather = Weather.COLD;
            IReciever receiver = new CommandExecutor(state, weather);
            receiver.SetAction(actionItem);

            // act
            bool result = receiver.GetResult();

            // assert
            Assert.IsFalse(result);
        }
    }
}
