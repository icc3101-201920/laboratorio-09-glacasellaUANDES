using Laboratorio_8_OOP_201920.Cards;
using Laboratorio_8_OOP_201920.Enums;
using System.Collections.Generic;

namespace Laboratorio_8_OOP_201920
{
    public static class Effect
    {
        private static Dictionary<EnumEffect, string> effectDescriptions = new Dictionary<EnumEffect, string>()
        {
            { EnumEffect.bitingFrost, "Sets the strength of all melee cards to 1 for both players" },
            { EnumEffect.impenetrableFog, "Sets the strength of all range cards to 1 for both players" },
            { EnumEffect.torrentialRain, "Sets the strength of all longRange cards to 1 for both players" },
            { EnumEffect.clearWeather, "Removes all Weather Card (Biting Frost, Impenetrable Fog and Torrential Rain) effects" },
            { EnumEffect.moraleBoost, "Adds +1 to all units in the row (excluding itself)" },
            { EnumEffect.spy, "Place on your opponent's battlefield (counts towards opponent's total) and draw 2 cards from your deck" },
            { EnumEffect.tightBond, "Place next to a card with the same name to double the strength of both cards" },
            { EnumEffect.buff, "Doubles the strength of all unit cards in that row. Limited to 1 per row" },
            { EnumEffect.none, "None" },
        };

        public static string GetEffectDescription(EnumEffect e)
        {
            return effectDescriptions[e];
        }

        public static void ApplyEffect(Card playedCard, Player activePlayer, Player opponent, Board board)
        {
            // En el enunciado dice que se debe implementar unicamente para weather
            if (playedCard.Type == EnumType.weather)
            {

                // Como el enunciado dice que se deben recuperar los valores de ataque de las cartas si alguna es eliminada,
                // lo que hice fue en la linea 251 de Game.cs llamar al metodo RecuperarValores cada vez que inicia un turno nuevo.
                // De esta forma, las cartas recuperan sus valores de ataque anteriores en cada turno, y, durante el turno con cada jugada
                // se engatilla el evento CardPlayed, que a su vez hace que se apliquen los efectos de todas las weather cards de ambos jugadores
                // (este metodo). SI una carta fue eliminada, no se llamara al evento por esa carta y se habran recuperado los valores de ataque.

                // Para guardar el valor de ataque anterior, modifique CombatCard.cs para agregarle un atributo que es la cantidad de ataque
                // que tenia la carta antes de que se le aplicara el efecto de una weather. Juego con esa propiedad para cambiar las propiedades

                switch (playedCard.CardEffect)
                {
                    case EnumEffect.bitingFrost:
                        PutAttackToOne(EnumType.melee, activePlayer, opponent);
                        break;

                    case EnumEffect.impenetrableFog:
                        PutAttackToOne(EnumType.range, activePlayer, opponent);
                        break;

                    case EnumEffect.torrentialRain:
                        PutAttackToOne(EnumType.longRange, activePlayer, opponent);
                        break;

                    case EnumEffect.clearWeather:
                        int c = 0;
                        foreach (Card card in activePlayer.Deck.Cards)
                        {
                            if (card.Type == EnumType.weather)
                            {
                                activePlayer.Deck.DestroyCard(c);
                            }
                            c++;
                        }

                        c = 0;
                        foreach (Card card in opponent.Deck.Cards)
                        {
                            if (card.Type == EnumType.weather)
                            {
                                opponent.Deck.DestroyCard(c);
                            }
                            c++;
                        }

                        RecuperarValores(activePlayer, opponent);
                        break;
                }
            }
        }

        // metodo que regresa a todas las cartas sus valores anteriores
        public static void RecuperarValores(Player pl1, Player pl2)
        {
            foreach (Card card in pl1.Deck.Cards)
            {
                if (card.Type == EnumType.melee || card.Type == EnumType.range || card.Type == EnumType.longRange)
                {
                    CombatCard cb = (CombatCard)card;
                    if (cb.PreviousAttackPoints != -1)
                    {
                        cb.AttackPoints = cb.PreviousAttackPoints;
                        cb.PreviousAttackPoints = -1;
                    }
                }
            }

            foreach (Card card in pl2.Deck.Cards)
            {
                if (card.Type == EnumType.melee || card.Type == EnumType.range || card.Type == EnumType.longRange)
                {
                    CombatCard cb = (CombatCard)card;
                    if (cb.PreviousAttackPoints != -1)
                    {
                        cb.AttackPoints = cb.PreviousAttackPoints;
                        cb.PreviousAttackPoints = -1;
                    }
                }
            }
        }

        // metodo para poner el ataque en 1 de todas las cartas de pl1 y pl2 del tipo type
        private static void PutAttackToOne(EnumType type, Player pl1, Player pl2)
        {
            foreach (Card card in pl1.Deck.Cards)
            {
                if (card.Type == type)
                {
                    CombatCard cb = (CombatCard)card;
                    // Guardamos en previousAttackPoints el valor de sus puntos de ataque (es un atributo que yo cree)
                    cb.PreviousAttackPoints = cb.AttackPoints;
                    // Ponemos los puntos de ataque a 1
                    cb.AttackPoints = 1;
                }
            }

            foreach (Card card in pl2.Deck.Cards)
            {
                if (card.Type == type)
                {
                    CombatCard cb = (CombatCard)card;
                    // Guardamos en previousAttackPoints el valor de sus puntos de ataque (es un atributo que yo cree)
                    cb.PreviousAttackPoints = cb.AttackPoints;
                    // Ponemos los puntos de ataque a 1
                    cb.AttackPoints = 1;
                }
            }
        }
    }
}
