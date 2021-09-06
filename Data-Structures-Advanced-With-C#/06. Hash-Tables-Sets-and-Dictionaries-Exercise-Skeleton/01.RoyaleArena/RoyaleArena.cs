namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> battleCards;

        public RoyaleArena()
        {
            battleCards = new Dictionary<int, BattleCard>();
        }

        public void Add(BattleCard card)
        {
            battleCards.Add(card.Id, card);
        }

        public bool Contains(BattleCard card)
        {
            return battleCards.ContainsKey(card.Id);
        }

        public int Count => battleCards.Count;

        public void ChangeCardType(int id, CardType type)
        {
            Exists(id);

            battleCards[id].Type = type;
        }

        public BattleCard GetById(int id)
        {
            Exists(id);

            return battleCards[id];
        }

        public void RemoveById(int id)
        {
            Exists(id);

            battleCards.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var cardsByType = battleCards
                .Select(c => c.Value)
                .Where(c => c.Type == type)
                .OrderByDescending(c => c.Name)
                .ThenBy(c => c.Id);

            IsCollectionEmpty(cardsByType);

            return cardsByType;
        }

        private void IsCollectionEmpty(IOrderedEnumerable<BattleCard> cardsByType)
        {
            if (cardsByType.Count() == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var orderedCards = battleCards
                .Select(c => c.Value)
                .Where(c => c.Type == type && c.Damage > lo && c.Damage < hi)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);

            IsCollectionEmpty(orderedCards);

            return orderedCards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var orderedCards = battleCards
               .Select(c => c.Value)
               .Where(c => c.Type == type && c.Damage <= damage)
               .OrderByDescending(c => c.Damage)
               .ThenBy(c => c.Id);

            IsCollectionEmpty(orderedCards);

            return orderedCards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var orderedCards = battleCards
              .Select(c => c.Value)
              .Where(c => c.Name == name)
              .OrderByDescending(c => c.Swag)
              .ThenBy(c => c.Id);

            IsCollectionEmpty(orderedCards);

            return orderedCards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var orderedCards = battleCards
             .Select(c => c.Value)
             .Where(c => c.Name == name && c.Swag >= lo && c.Swag < hi)
             .OrderByDescending(c => c.Swag)
             .ThenBy(c => c.Id);

            IsCollectionEmpty(orderedCards);
            return orderedCards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > Count)
            {
                throw new InvalidOperationException();
            }

            var orderedCards = battleCards
             .Select(c => c.Value)
             .OrderBy(c => c.Swag)
             .ThenBy(c => c.Id)
             .Take(n);

            return orderedCards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            var orderedCards = battleCards
             .Select(c => c.Value)
             .Where(c => c.Swag >= lo && c.Swag <= hi)
             .OrderBy(c => c.Swag);

            return orderedCards;
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in battleCards)
            {
                yield return card.Value;
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Exists(int id)
        {
            if (!battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
        }
    }
}