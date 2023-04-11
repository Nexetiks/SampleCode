using System;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class ManaController
    {
        [field: SerializeField]
        public int Mana { get; private set; }

        public void AddMana(int amount)
        {
            Mana += amount;
        }

        public void RemoveMana(int amount)
        {
            Mana -= amount;
        }
    }
}