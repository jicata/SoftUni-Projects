using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListIteratorrTests
{
    using System;
    using System.Collections.Generic;
    using ListIteratorr;

    [TestClass]
    public class ListIteratorrTests
    {
        private ListIterator listIteratorr;

        [TestInitialize]
        public void Init()
        {
            this.listIteratorr = new ListIterator();
        }

        [TestMethod]
        public void ConstructorShouldInitializeCollectionWithGivenNonEmptyCollection()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            CollectionAssert.AreEqual(expected, this.listIteratorr.Collection, "Collections are not equal");
        }

        [TestMethod]
        public void ConstructorShouldInitializeCollectionWithGivenEmptyCollection()
        {
            List<string> expected = new List<string>();
            this.listIteratorr = new ListIterator(expected);
            Assert.AreEqual(0, this.listIteratorr.Collection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorShouldThrowWithNullCollection()
        {
            List<string> expected = null;
            this.listIteratorr = new ListIterator(expected);
        }
        [TestMethod]
        public void OneMoveWithTwoElementsShouldReturnTrue()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            bool hasMoved = this.listIteratorr.Move();
            Assert.IsTrue(hasMoved);
        }
        [TestMethod]
        public void TwoMovesWithTwoElementsShouldReturnFalse()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            this.listIteratorr.Move();
            bool hasMoved = this.listIteratorr.Move();
            Assert.IsFalse(hasMoved);
        }
        [TestMethod]
        public void OneMoveShouldMoveInternalIndexByOne()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            int beforeMoveIndex = this.listIteratorr.CurrentIndex;
            this.listIteratorr.Move();
            int afterMoveIndex = this.listIteratorr.CurrentIndex;
            Assert.AreEqual(0, beforeMoveIndex);
            Assert.AreEqual(1, afterMoveIndex, "Move doesn't move the internal index");
        }
        [TestMethod]
        public void TwoMoveShouldMoveInternalIndexByOne()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            int beforeMoveIndex = this.listIteratorr.CurrentIndex;
            this.listIteratorr.Move();
            int afterMoveIndex = this.listIteratorr.CurrentIndex;
            Assert.AreEqual(0, beforeMoveIndex);
            Assert.AreEqual(1, afterMoveIndex, "Move doesn't move the internal index");
        }
        [TestMethod]
        public void HasNextWithNoMoveOnCollectionWithTwoElementsShouldReturnTrue()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            bool hasNext = this.listIteratorr.HasNext();
            Assert.IsTrue(hasNext);
        }
        [TestMethod]
        public void HasNextWitheOneMoveOnCollectionWithTwoElementsShouldReturnFalse()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            this.listIteratorr.Move();
            bool hasNext = this.listIteratorr.HasNext();
            Assert.IsFalse(hasNext);
        }
        [TestMethod]
        public void PrintWithNoMoveShouldReturn0thElement()
        {
            List<string> expected = new List<string>() { "Pesho", "Stamat" };
            this.listIteratorr = new ListIterator(expected);
            string result = this.listIteratorr.Print();
            Assert.AreEqual(expected[0], result, "Print does not return the correct element");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PrintOnEmptyCollectionShouldThrow()
        {
            List<string> expected = new List<string>() { };
            this.listIteratorr = new ListIterator(expected);
            string result = this.listIteratorr.Print();
            
        }

    }
}
