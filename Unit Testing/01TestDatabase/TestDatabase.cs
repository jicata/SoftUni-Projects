using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01Database;
using System.Collections.Generic;

namespace _01TestDatabase
{
    [TestClass]
    public class TestDatabase
    {
        Database db;

        [TestInitialize]
        public void TestInitialize()
        {
            this.db = new Database(new int[] { 1,2,3,4});
            //init without params
        }

        [TestMethod]
        public void TestDatabaseCapacity()
        {
            Assert.AreEqual(16, db.Capacity, "Database capacity is not 16");
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            db.Add(10);
            Assert.AreEqual(5, db.Count);
        }

        [TestMethod]
        public void TestAddSeveralElements()
        {
            db.Add(19);
            db.Add(10);
            db.Add(-1);
            Assert.AreEqual(7, db.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddMoreElementsThanCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                db.Add(i);
            }
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            db.Remove();
            Assert.AreEqual(3, db.Count);
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            Assert.AreEqual(1, db.Count);
            CollectionAssert.AreEqual(new int[] { 1 }, db.Elements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveFromEmptyDatabase()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
        }

        [TestMethod]
        public void TestConstructorValidParameters()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            db = new Database(numbers);
            CollectionAssert.AreEqual(numbers, db.Elements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorInValidParametersShouldThrow()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 9, -1, -2, -3, -5, 10, 15, 20, 30, 40, 50 };
            db = new Database(numbers);
        }

        [TestMethod]
        public void TestElementsGetterInitialValuesFromConstructor()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterNoElements()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            db.Remove();
            CollectionAssert.AreEqual(new int[] { }, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterOneElement()
        {
            db.Remove();
            db.Remove();
            db.Remove();
            CollectionAssert.AreEqual(new int[] { 1 }, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSeveralElements()
        {
            db.Add(10);
            db.Add(15);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 10, 15 }, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSixteenElements()
        {
            List<int> expected = new List<int>(new int[] { 1, 2, 3, 4 });
            for (int i = 0; i < 12; i++)
            {
                db.Add(i);
                expected.Add(i);
            }

            CollectionAssert.AreEqual(expected, db.Elements);
        }
    }
}
