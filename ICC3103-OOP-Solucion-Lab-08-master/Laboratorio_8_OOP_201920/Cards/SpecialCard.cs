using Laboratorio_8_OOP_201920.Enums;
using Laboratorio_8_OOP_201920.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_8_OOP_201920.Cards
{
    [Serializable]
    public class SpecialCard : Card
    {
        //Atributos
        private string buffType;

        //Propiedades
        public string BuffType
        {
            get
            {
                return this.buffType;
            }
            set
            {
                this.buffType = value;
            }
        }
        //Constructor
        public SpecialCard(string name, EnumType type, EnumEffect effect)
        {
            Name = name;
            Type = type;
            CardEffect = effect;
            BuffType = null;
        }

        public override List<string> GetCharacteristics()
        {
            return new List<string>() {
                $"Name: {Name}",
                $"Type: {Type.ToString()}",
                $"Effect: {Effect.GetEffectDescription(CardEffect)}",
            };
        }
    }
}
