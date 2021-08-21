namespace _01.Hierarchy.Tests.Correctness
{
    using NUnit.Framework;
    public class Constructor
    {
        [Test]
        public void Constructor_NewHierarchyShouldHaveExactly1Element()
        {
            var hierarchy = new Hierarchy<int>(5);
            Assert.AreEqual(1, hierarchy.Count);
        }

        [Test]
        public void Constructor_NewHierarchyShouldHaveCorrectElement()
        {
            var hierarchy = new Hierarchy<int>(5);
            Assert.IsTrue(hierarchy.Contains(5));
        }

        [Test]
        public void Hierarchy_ShouldBeGeneric()
        {
            var hierarchy = new Hierarchy<string>("test");
            Assert.IsTrue(hierarchy.Contains("test"));
        }
    }
}
