using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SODV2202_FinalProject
{
    public class UnoCard
    {
        public string Color { get; set; }
        public string Value { get; set; }

        public UnoCard(string color, string value)
        {
            Color = color;
            Value = value;
        }
        public string GetImagePath()
        {
            string colorCode = Color[0].ToString().ToLower(); // e.g., "r" for Red
            string valueCode = Value.Replace(" ", "").ToLower(); // Remove spaces for "draw 4"
            return @$"images\\{colorCode}-{valueCode}.png";
        }
        public override string ToString()
        {
            return $"{Color} {Value}";
        }
    }

    public class UnoDeck
    {
        public List<UnoCard> deck = new List<UnoCard>();
        public List<UnoCard> discardPile = new List<UnoCard>();
        private Random random = new Random();

        public UnoDeck()
        {
            string[] colors = { "Red", "Green", "Blue", "Yellow" };
            string[] values = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Skip", "Reverse", "Draw 2" };
            // Add regular cards
            foreach (var color in colors)
            {
                foreach (var value in values)
                {
                    deck.Add(new UnoCard(color, value)); // One card for "0"
                    if (value != "0") deck.Add(new UnoCard(color, value)); // Two cards for other values
                }
            }
            // Add Wild cards
            for (int i = 0; i < 4; i++)
            {
                deck.Add(new UnoCard("Wild", "Wild"));
                deck.Add(new UnoCard("Wild", "Draw 4"));
            }
            Shuffle(deck);
        }
        public void Shuffle(List<UnoCard> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        public void Reshuffle()
        {
            if (discardPile.Count <= 1) return;
            //Shuffle the discard pile, add back to the deck and clear discard pile
            var reshufflePile = discardPile.Except(new[] { discardPile.Last() }).ToList();
            
            Shuffle(reshufflePile);
            deck.AddRange(reshufflePile);
            discardPile = new List<UnoCard> { discardPile.Last() };
        }
        public UnoCard DrawCard()
        {
            if (deck.Count == 0) return null;
            int index = random.Next(deck.Count);
            UnoCard card = deck[index];
            deck.RemoveAt(index);
            return card;
        }

        public int RemainingCards => deck.Count;
    }

}
