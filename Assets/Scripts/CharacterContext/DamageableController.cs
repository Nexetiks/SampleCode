using System;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class DamageableController
    {
        [field: SerializeField]
        public int HP { get; private set; }
        [field: SerializeField]
        public int Shield { get; private set; }

        public void AddHp(int amount)
        {
            HP += amount;
        }

        public void AddShield(int amount)
        {
            Shield += amount;
        }

        public void DamageCharacter(int amount)
        {
            Shield -= amount;

            if (Shield < 0)
            {
                HP += Shield;
                Shield = 0;
            }

            if (HP <= 0)
            {
                HP = 0;
                Debug.Log("Killed");
            }
        }
    }
}