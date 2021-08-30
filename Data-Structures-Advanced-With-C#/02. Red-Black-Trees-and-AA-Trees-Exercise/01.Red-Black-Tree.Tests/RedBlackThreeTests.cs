namespace _01.Red_Black_Tree.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class RedBlackThreeTests
    {
        private RedBlackTree<string> RedBlackTree;
        private string[] input = {
            "S",
            "E",
            "A",
            "R",
            "C",
            "H",
            "E",
            "X",
            "A",
            "M",
            "P",
            "L",
            "E"
        };

        [SetUp]
        public void Setup()
        {
            this.RedBlackTree = new RedBlackTree<string>();

            for (int i = 0; i < input.Length; i++)
            {
                this.RedBlackTree.Insert(input[i]);
            }
        }

        [Test]
        public void TestEachInOrder()
        {
            List<string> expected = new List<string>
            {
                "A",
                "C",
                "E",
                "H",
                "L",
                "M",
                "P",
                "R",
                "S",
                "X"
            };

            Assert.AreEqual(expected.Count, this.RedBlackTree.Count);

            int count = 0;
            this.RedBlackTree.EachInOrder(n => StringAssert.AreEqualIgnoringCase(n, expected[count++]));

            var list = new List<string>();
            this.RedBlackTree.EachInOrder(n => list.Add(n));

            CollectionAssert.AreEqual(list, expected);
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(10, this.RedBlackTree.Count);
            Assert.AreEqual(0, new RedBlackTree<string>().Count);
        }

        [Test]
        public void TestContains()
        {
            Assert.True(this.RedBlackTree.Contains("H"));
            Assert.False(this.RedBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestInsert()
        {
            Assert.False(this.RedBlackTree.Contains("Pesho"));
            this.RedBlackTree.Insert("Pesho");
            Assert.True(this.RedBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestSecondInsert()
        {
            Assert.False(this.RedBlackTree.Contains("Pesho"));
            this.RedBlackTree.Insert("Pesho");
            Assert.True(this.RedBlackTree.Contains("Pesho"));
        }

        [Test]
        public void TestDeleteMin()
        {
            this.RedBlackTree.DeleteMin();
            Assert.AreEqual(9, this.RedBlackTree.Count);
            Assert.False(this.RedBlackTree.Contains("A"));
        }

        [Test]
        public void TestDeleteMax()
        {
            this.RedBlackTree.DeleteMax();
            Assert.AreEqual(9, this.RedBlackTree.Count);
            Assert.False(this.RedBlackTree.Contains("X"));
        }

        [Test]
        public void TestDelete()
        {
            this.RedBlackTree.Delete("M");
            Assert.AreEqual(9, this.RedBlackTree.Count);
            Assert.False(this.RedBlackTree.Contains("M"));
        }

        [Test]
        public void TestSelect()
        {
            string selected = this.RedBlackTree.Select(3);
            Assert.NotNull(selected);
            Assert.AreEqual("H", selected);
        }

        [Test]
        public void TestRank()
        {
            int rank = this.RedBlackTree.Rank("H");
            Assert.AreEqual(3, rank);
        }

        [Test]
        public void TestCeiling()
        {
            string ceil = this.RedBlackTree.Ceiling("A");
            Assert.AreEqual("C", ceil);
        }

        [Test]
        public void TestFloor()
        {
            string floor = this.RedBlackTree.Floor("B");
            Assert.AreEqual("A", floor);
        }
    }
}
