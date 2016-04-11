using System;
using NUnit.Framework;
using LeaveTheHouseApp;

namespace LeaveTheHouseAppTest
{
    [TestFixture]
    public class InputProcessorTests
    {

        #region Valid Input Tests

        static object[] ValidCase1 = new object[] {new[] {"HOT", "8,", "6,", "4,", "2,", "1,", "7," }};
        
        // success cases

        [Test]
        [TestCaseSource("ValidCase1")]
        public void ValidInputTest1(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house", output);
        }

        static object[] ValidCase2 = new object[] { new[] { "COLD", "8,", "6,", "3,", "4,", "2,", "5,", "1,", "7" } };

        [Test]
        [TestCaseSource("ValidCase2")]
        public void ValidInputTest2(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house", output);
        }

        // failure cases

        static object[] ValidCase3 = new object[] { new[] { "HOT", "8,", "6,", "6" } };

        [Test]
        [TestCaseSource("ValidCase3")]
        public void ValidInputTest3(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: Removing PJs, shorts, fail", output);
        }

        static object[] ValidCase4 = new object[] { new[] { "HOT", "8,", "6,", "3" } };

        [Test]
        [TestCaseSource("ValidCase4")]
        public void ValidInputTest4(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: Removing PJs, shorts, fail", output);
        }

        static object[] ValidCase5 = new object[] { new[] { "COLD", "8,", "6,", "3,", "4,", "2,", "5,", "7" } };

        [Test]
        [TestCaseSource("ValidCase5")]
        public void ValidInputTest5(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: Removing PJs, pants, socks, shirt, hat, jacket, fail", output);
        }

        static object[] ValidCase6 = new object[] { new[] { "COLD", "6" } };

        [Test]
        [TestCaseSource("ValidCase6")]
        public void ValidInputTest6(string[] args)
        {
            string processorResult = InputProcessor.ProcessInputs(args);
            string output = "Output: " + processorResult;

            Assert.AreEqual("Output: fail", output);
        }

        #endregion Valid Input Tests

        #region Invalid Input Tests

        static object[] InvalidCase1 = new object[] { new[] { "COLD", "8,3,", " 4" } };

        [Test]
        [TestCaseSource("InvalidCase1")]
        public void InvalidInputTest1(string[] args)
        {
            var ex = Assert.Throws<FormatException> (() => InputProcessor.ProcessInputs(args));

            Assert.AreEqual(ex.Message, "An error occurred when parsing command inputs. Please provide comman separated integers with a space after each integer value.");
        }

        //static object[] InvalidCase2 = new object[] { new[] { "HOT", "" } };

        [Test]
        public void InvalidInputTest2()
        {
            string[] args = new string[1];

            args[0] = "HOT";

            var ex = Assert.Throws<ArgumentException>(() => InputProcessor.ProcessInputs(args));

            Assert.AreEqual(ex.Message, "Please provide a weather state followed by integer commands.");
        }

        static object[] InvalidCase3 = new object[] { new[] { "COLD", "8,", "9" } };
        
        [Test]        
        [TestCaseSource("InvalidCase3")]
        public void InvalidInputTest3(string[] args)
        {
            var ex = Assert.Throws<ArgumentException>(() => InputProcessor.ProcessInputs(args));

            Assert.AreEqual(ex.Message, "Command set could not be created. Please provide integers between 1 and 8.");
        }

        #endregion Invalid Input Tests
    }
}
