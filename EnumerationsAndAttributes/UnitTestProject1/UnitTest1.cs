using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {
        private List<string> strings;

        [TestInitialize]
        public void Init()
        {
            this.strings = new List<string>();
        }


       
        public void TestMethod1()
        {
            this.strings.Add("Pesho");
            Assert.AreEqual("Pesho",this.strings[1]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            this.strings.Add("Gosho");
            Assert.AreEqual("Gosho", this.strings[0]);
        }

        
    }
}
