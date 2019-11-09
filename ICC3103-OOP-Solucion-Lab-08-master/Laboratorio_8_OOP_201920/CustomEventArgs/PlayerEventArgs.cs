using Laboratorio_8_OOP_201920.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_8_OOP_201920
{
    public class PlayerEventArgs : EventArgs
    {
        Card card;
        Player player;

        public Card Card { get => this.card; set => this.card = value; }
        public Player Player { get => this.player; set => this.player = value; }
    }
}
