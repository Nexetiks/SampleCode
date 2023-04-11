using System;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class CharacterContext
    {
        [field: SerializeField]
        public DamageableController DamageableController { get; private set; }
        [field: SerializeField]
        public ManaController ManaController { get; private set; }
    }
}