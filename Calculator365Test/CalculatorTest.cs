using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator365;

namespace Calculator365Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void OnePos()
        {
            //Setup
            string arg1 = "1";
            string expected = "1";
            string actual;
            Calculator calc = new Calculator();


            //Assert
            actual = calc.Calculate(arg1);
            Assert.AreEqual(expected, actual);
        }
    }
}
