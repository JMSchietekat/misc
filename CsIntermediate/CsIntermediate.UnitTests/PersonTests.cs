using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsIntermediate.UnitTests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Age_ValidCondition_Equals()
        {
            var age = 30;
            var person = new Person(DateTime.Now.AddYears(-age));
            
            Assert.AreEqual(age, person.Age);
        }
    }
}