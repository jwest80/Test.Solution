using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.Extensions.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        [TestMethod()]
        public void RemoveDuplicatesFromCSV()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(  // Removes Duplicates?
                expected: "a,b,c,d,e",
                actual: "a,a,b,b,c,c,d,d,e,e".RemoveDuplicatesFromCSV());

            Assert.AreEqual(  // Ignores Spacing
                expected: "a,b,c,d,e",
                actual: "a , a, b,b ,c ,c ,d, d,  e , e".RemoveDuplicatesFromCSV());

            Assert.AreEqual(  // Ignores Case
                expected: "a,b,c,d,e",
                actual: "a, A, B,b ,c ,c ,D, d,e ,e".RemoveDuplicatesFromCSV());

        }
    }
}