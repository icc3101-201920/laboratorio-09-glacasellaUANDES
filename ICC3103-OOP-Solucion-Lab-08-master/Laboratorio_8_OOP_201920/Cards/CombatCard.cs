using Laboratorio_8_OOP_201920.Enums;
using Laboratorio_8_OOP_201920.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_8_OOP_201920.Cards
{
    [Serializable]
    public class CombatCard : Card
    {
        //Atributos
        private int attackPoints;
        private int originalAttackPoints;
        private bool hero;
        private int previousAttackPoints;

        //Constructor
        public CombatCard(string name, EnumType type, EnumEffect effect, int attackPoints, bool hero)
        {
            Name = name;
            Type = type;
            CardEffect = effect;
            AttackPoints = attackPoints;
            OriginalAttackPoints = attackPoints;
            Hero = hero;
            PreviousAttackPoints = -1;
        }

        //Propiedades
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public int OriginalAttackPoints { get => originalAttackPoints; private set => originalAttackPoints = value; }
        public bool Hero
        { get
            {
                return this.hero;
            }
            set
            {
                this.hero = value;
            }
        }

        public int PreviousAttackPoints { get => this.previousAttackPoints; set => this.previousAttackPoints = value; }

        public override List<string> GetCharacteristics()
        {
            return new List<string>() {
                $"Name: {Name}",
                $"Type: {Type.ToString()}",
                $"Effect: {Effect.GetEffectDescription(CardEffect)}",
                $"AttackPoints: {AttackPoints}",
                $"Hero: {Hero}",
            };
        }
    }
}
