namespace _02TestExtendedDatabase
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _02ExtendedDatabase;
    using System;

    [TestClass]
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase db;

        [TestInitialize]
        public void TestInitialize()
        {
            List<Person> initalPeople = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };

            db = new ExtendedDatabase(initalPeople);
        }

        [TestMethod]
        public void TestDatabaseCapacity()
        {
            Assert.AreEqual(16, db.Capacity, "Database capacity is not 16");
        }

        [TestMethod]
        public void TestAddOneElement()
        {
            db.Add(new Person(3, "Mitko"));
            Assert.AreEqual(3, db.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateIdPersonShouldThrow()
        {
            db.Add(new Person(2, "Pesho"));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddDuplicateUsernamePersonShouldThrow()
        {
            db.Add(new Person(3, "Misho"));
        }

        [TestMethod]
        public void TestAddSeveralElements()
        {
            db.Add(new Person(3, "Mitko1"));
            db.Add(new Person(4, "Mitko2"));
            db.Add(new Person(5, "Mitko3"));
            Assert.AreEqual(5, db.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddMoreElementsThanCapacity()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "Mitko" + i));
            }
        }

        [TestMethod]
        public void TestRemoveOneElement()
        {
            db.Remove();
            Assert.AreEqual(1, db.Count);
        }

        [TestMethod]
        public void TestRemoveSeveralElements()
        {
            db.Remove();
            Assert.AreEqual(1, db.Count);
            CollectionAssert.AreEqual(new Person[] { new Person(1, "Misho") }, db.Elements);
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
            Person[] expectedPeople = new Person[]
            {
                new Person(3, "Mitko1"),
                new Person(4, "Mitko2"),
                new Person(5, "Mitko3")
            };
            db = new ExtendedDatabase(expectedPeople);
            CollectionAssert.AreEqual(expectedPeople, db.Elements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestConstructorInValidParametersShouldThrow()
        {
            List<Person> expectedPeople = new List<Person>();
            for (int i = 3; i < 21; i++)
            {
                expectedPeople.Add(new Person(i, "Mitko"+i));

            }
            db = new ExtendedDatabase(expectedPeople);
        }

        [TestMethod]
        public void TestElementsGetterInitialValuesFromConstructor()
        {
            List<Person> expectedPeople = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };
            CollectionAssert.AreEqual(expectedPeople, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterNoElements()
        {
            db.Remove();
            db.Remove();
            CollectionAssert.AreEqual(new Person[] { }, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterOneElement()
        {
            db.Remove();
            CollectionAssert.AreEqual(new Person[] { new Person(1, "Misho") }, db.Elements);
        }
        
        [TestMethod]
        public void TestElementsGetterSeveralElements()
        {
            db.Add(new Person(3, "Mitko3"));
            db.Add(new Person(4, "Mitko4"));
            Person[] expectedPeople = new Person[]
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho"),
                new Person(3, "Mitko3"),
                new Person(4, "Mitko4")
            };
            CollectionAssert.AreEqual(expectedPeople, db.Elements);
        }

        [TestMethod]
        public void TestElementsGetterSixteenElements()
        {
            List<Person> expected = new List<Person>()
            {
                new Person(1, "Misho"),
                new Person(2, "Gosho")
            };
            for (int i = 3; i < 17; i++)
            {
                Person p = new Person(i, "Goshko" + i);
                db.Add(p);
                expected.Add(p);
            }

            CollectionAssert.AreEqual(expected, db.Elements);
        }

        [TestMethod]
        public void TestFindByIdValidParametersShouldPass()
        {
            Person expected = new Person(1, "Misho");
            Person actual = db.FindById(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFindByIdNegativeIdShouldThrow()
        {
            db.FindById(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFindByUsernameNullParameterShouldThrow()
        {
            db.FindByUsername(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByIdUserNotFoundShouldThrow()
        {
            db.FindById(100);
        }

        [TestMethod]
        public void TestFindByUsernameValidParametersShouldPass()
        {
            Person expected = new Person(2, "Gosho");
            Person actual = db.FindByUsername("Gosho");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFindByUsernameUserNotFoundShouldThrow()
        {
            db.FindByUsername("Toshko");
        }
    }
}
