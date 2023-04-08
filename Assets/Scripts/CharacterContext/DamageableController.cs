using System;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class DamageableController
    {
        [field: SerializeField]
        public float HP { get; private set; }
        [field: SerializeField]
        public float Shield { get; private set; }

        public void AddHp(float amount)
        {
            HP += amount;
        }

        public void AddShield(float amount)
        {
            Shield += amount;
        }

        public void DamageCharacter(float amount)
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
                Debug.Log(" Killed");
            }
        }
    }
}