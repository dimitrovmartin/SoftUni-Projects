namespace _01.RoyaleArena.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using  _01.RoyaleArena;

    public class RoyaleArenaTests
    {
        [Test]
        public void Add_SingleElement_ShouldWorkCorrectly() {
            IArena RA = new RoyaleArena();
            BattleCard cd = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
            RA.Add(cd);

            //Assert
            foreach (var bc in RA) 
            {
                Assert.AreEqual(bc, cd);
            }
        }

        [Test]
        public void Contains_OnExistingElement_ShouldReturnTrue()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 6, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 7, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 8, 5);

            //Act
            RA.Add(cd1);
            RA.Add(cd2);
            RA.Add(cd3);
            //Assert

            Assert.True(RA.Contains(cd1));
            Assert.False(RA.Contains(new BattleCard(3, CardType.BUILDING, "ta", 6, 52.2)));
            Assert.True(RA.Contains(cd2));
            Assert.False(RA.Contains(new BattleCard(0, CardType.RANGED, "b", 7, 5)));
        }

        [Test]
        public void Count_Should_IncreaseOnMultiple_Elements()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 3, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 8, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 9, 5);

            //Act
            RA.Add(cd1);
            RA.Add(cd2);
            RA.Add(cd3);

            //Assert
            Assert.AreEqual(3, RA.Count);
        }

        [Test]
        public void GetById_On_ExistingElement_ShouldWorkCorrectly()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

            //Act
            RA.Add(cd1);
            RA.Add(cd2);
            RA.Add(cd3);

            //Assert
            Assert.AreEqual(cd1, RA.GetById(5));
            Assert.AreNotEqual(
                new BattleCard(53, CardType.RANGED, "a", 10, 5),
                RA.GetById(7)
            );
        }

        [Test]
        public void ChangeCardType_ShouldWorkCorrectly_On_Existingcd()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 10, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 10, 5);

            //Act
            RA.Add(cd1);
            RA.Add(cd2);
            RA.Add(cd3);
            RA.ChangeCardType(5, CardType.MELEE);

            //Assert
            Assert.AreEqual(CardType.MELEE, cd1.Type);
            Assert.AreEqual(3, RA.Count);
        }

        [Test]
        public void RA_ShouldBeEnumeratedIn_InsertionOrder()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 5, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 6, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 7, 5);
            List<BattleCard> expected = new List<BattleCard>() {cd1,cd3,cd2};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);

            List<BattleCard> actual = new List<BattleCard>();

            foreach (BattleCard battlecard in RA) 
            {
                actual.Add(battlecard);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void RA_ShouldReturn_BattlecardsInCorrectOrder_AfterDelete() {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 10, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 11, 5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 12, 5);
            List<BattleCard> expected = new List<BattleCard>() {cd2} ;

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.RemoveById(5);
            RA.RemoveById(7);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (BattleCard battlecard in RA) 
            {
                actual.Add(battlecard);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetInSwagRange_ShouldReturn_CorrectBattlecards()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "dragon", 8, 1);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "raa", 7, 2);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "maga", 6, 5.5);
            BattleCard cd4 = new BattleCard(12, CardType.SPELL, "shuba", 5, 15.6);
            BattleCard cd5 = new BattleCard(15, CardType.SPELL, "tanuki", 5, 7.8);
            List<BattleCard> expected = new List<BattleCard>() {cd5, cd4};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);
            IEnumerable<BattleCard> battlecards = RA.GetAllInSwagRange(7, 16);
            List<BattleCard> actual = new List<BattleCard>();

            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FindFirstLeastSwag_ShouldWorkCorrectly()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 6.0, 1.0);
            BattleCard cd2 = new BattleCard(6, CardType.MELEE, "joro", 7.0, 5.5);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 11.0, 5.5);
            BattleCard cd4 = new BattleCard(12, CardType.BUILDING, "joro", 12.0, 15.6);
            BattleCard cd5 = new BattleCard(15, CardType.BUILDING, "moro", 13.0, 7.8);
            List<BattleCard> expected = new List<BattleCard>() {cd1,cd2,cd3,cd5};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);
            IEnumerable<BattleCard> battlecards = RA.FindFirstLeastSwag(4);

            List<BattleCard> actual = new List<BattleCard>();
            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldWorkCorrectly_On_CorrectRange()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(5, CardType.SPELL, "joro", 1, 5);
            BattleCard cd2 = new BattleCard(6, CardType.SPELL, "joro", 5.5, 6);
            BattleCard cd3 = new BattleCard(7, CardType.SPELL, "joro", 5.5, 7);
            BattleCard cd4 = new BattleCard(12, CardType.SPELL, "joro", 15.6, 10);
            BattleCard cd5 = new BattleCard(15, CardType.RANGED, "joro", 7.8, 6);
            List<BattleCard> expected = new List<BattleCard>() {cd4, cd2, cd3, cd1};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);
            //Assert
            IEnumerable<BattleCard> battlecards = RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var b in battlecards) 
            {
                actual.Add(b);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByName_ShouldWorkCorrectly()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 5, 1);
            BattleCard cd2 = new BattleCard(1, CardType.SPELL, "joro", 6, 1);
            BattleCard cd3 = new BattleCard(4, CardType.SPELL, "joro", 7, 15.6);
            BattleCard cd4 = new BattleCard(3, CardType.SPELL, "joro", 8, 15.6);
            BattleCard cd5 = new BattleCard(8, CardType.RANGED, "joro", 11, 17.8);
            List<BattleCard> expected = new List<BattleCard>() {cd5, cd4, cd3, cd2, cd1};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);

            //Assert
            IEnumerable<BattleCard> joro = RA.GetByNameOrderedBySwagDescending("joro");
            List<BattleCard> actual = new List<BattleCard>();

            foreach (var item in joro)
            {
                actual.Add(item);
            }
            CollectionAssert.AreEquivalent(expected, actual);
        }


        [Test]
        public void GetByCardTypeAndMaximumDamage_ShouldWorkCorrectly_OnExistingSender()
        {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.SPELL, "joro", 1, 5);
            BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 14.8, 6);
            BattleCard cd3 = new BattleCard(3, CardType.SPELL, "valq", 15.6, 12);
            BattleCard cd4 = new BattleCard(4, CardType.SPELL, "valq", 15.6, 61);
            BattleCard cd5 = new BattleCard(8, CardType.SPELL, "valq", 17.8, 13);
            List<BattleCard> expected = new List<BattleCard>() {cd3, cd4, cd2, cd1};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);

            //Assert
            IEnumerable<BattleCard> battlecards = RA.GetByCardTypeAndMaximumDamage(CardType.SPELL, 15.6);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var item in battlecards)
            {
                actual.Add(item);
            }
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByCardType_ShouldReturnCorrectResultAfterRemove() {
            //Arrange
            IArena RA = new RoyaleArena();
            BattleCard cd1 = new BattleCard(2, CardType.SPELL, "valq", 2, 14.8);
            BattleCard cd2 = new BattleCard(1, CardType.SPELL, "valq", 2, 14.8);
            BattleCard cd3 = new BattleCard(4, CardType.SPELL, "valq", 4, 15.6);
            BattleCard cd4 = new BattleCard(3, CardType.SPELL, "valq", 3, 15.6);
            BattleCard cd5 = new BattleCard(8, CardType.RANGED, "valq", 8, 17.8);
            List<BattleCard> expected = new List<BattleCard>() {cd3, cd2, cd1};

            //Act
            RA.Add(cd1);
            RA.Add(cd3);
            RA.Add(cd2);
            RA.Add(cd4);
            RA.Add(cd5);
            RA.RemoveById(8);
            RA.RemoveById(3);

            //Assert
            IEnumerable<BattleCard> battlecards = RA.GetByCardType(CardType.SPELL);
            List<BattleCard> actual = new List<BattleCard>();
            foreach (var item in battlecards)
            {
                actual.Add(item);
            }
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
