using Laboratorio_8_OOP_201920.Cards;
using Laboratorio_8_OOP_201920.Enums;
using Laboratorio_8_OOP_201920.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboratorio_8_OOP_201920
{
    [Serializable]
    public class Deck : ICharacteristics
    {

        private List<Card> cards;

        public Deck()
        {
        
        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        public void DestroyCard(int cardId)
        {
            cards.RemoveAt(cardId);
        }

        public List<string> GetCharacteristics()
        {
            int totalCards = (from card in Cards select card).Count();
            int totalMeleeCards = (from card in Cards where card.Type == EnumType.melee select card).Count();
            int totalRangeCards = (from card in Cards where card.Type == EnumType.range select card).Count();
            int totalLongRangeCards = (from card in Cards where card.Type == EnumType.longRange select card).Count();
            int totalBuffCards = (from card in Cards where card.Type == EnumType.buff select card).Count();
            int totalWeatherCards = (from card in Cards where card.Type == EnumType.weather select card).Count();
            var allCards = (from card in Cards where (card.Type == EnumType.melee || card.Type == EnumType.range || card.Type == EnumType.longRange) select card as CombatCard);
            int meleeAttackPoints = (from card in allCards where card.Type == EnumType.melee select card.AttackPoints).Sum();
            int rangeAttackPoints = (from card in allCards where card.Type == EnumType.range select card.AttackPoints).Sum();
            int longRangeAttackPoints = (from card in allCards where card.Type == EnumType.longRange select card.AttackPoints).Sum();
            int totalAttackPoints = meleeAttackPoints + rangeAttackPoints + longRangeAttackPoints;
            return new List<string>()
            {
                $"Total Cards: {totalCards}",
                $"Melee Cards: {totalMeleeCards}",
                $"Range Cards: {totalRangeCards}",
                $"LongRange Cards: {totalLongRangeCards}",
                $"Buff Cards: {totalBuffCards}",
                $"Weather Cards: {totalWeatherCards}",
                $"Melee Attack Points: {meleeAttackPoints}",
                $"Range Attack Points: {rangeAttackPoints}",
                $"LongRange Attack Points: {longRangeAttackPoints}",
                $"Total Attack Points: {totalAttackPoints}",
            };
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

    }
}
