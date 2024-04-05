using Microsoft.VisualStudio.TestTools.UnitTesting;
using First_ex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_ex.Tests
{
    [TestClass()]
    public class DecimalTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Decimal a = new Decimal(1, 2);
            Decimal b = new Decimal(5, 9);
            Decimal c = new Decimal(19, 18);
            Assert.IsTrue(a + b == c);
        }
    }
}