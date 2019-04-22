using System;
using System.Text;

namespace SharpDeck
{
    static class CardTranslator
    {
        public static string Translate(Card card)
        {
            var rank = card.Rank;
            var suit = card.Suit;
            var rankString = Enum.GetName(typeof(Rank), rank);
            var suitString = Enum.GetName(typeof(Suit), suit);
            var sb = new StringBuilder();
            sb.Append(rankString);
            if (!card.IsJoker)
            {

                sb.Append(" of ");
                sb.Append(suitString);
            }
            return sb.ToString(); //"Ace of Spades", "Joker"
        }

        public static string MaxetaTranslate(Card card)
        {
            if (card.Rank != Rank.Joker) //card.IsJoker did not work. Unsure why. Maybe b/c jokres have suits in moded version?
            {
                return Translate(card);
            }
            else
            {
                return "Penalty Card";
            }           
        }
    }
}
