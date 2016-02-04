using Microsoft.VisualStudio.TestTools.UnitTesting;
using Middleware.Wm.Extensions;

namespace WMMiddleware.Common.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestConvertIntegerToCharacter()
        {
            Assert.AreEqual('0', "0".ConvertIntegerToCharacter());
            Assert.AreEqual('9', "9".ConvertIntegerToCharacter());
            Assert.AreEqual('A', "10".ConvertIntegerToCharacter());
            Assert.AreEqual('E', "14".ConvertIntegerToCharacter());
            Assert.AreEqual('Z', "35".ConvertIntegerToCharacter());
        }
    }
}
