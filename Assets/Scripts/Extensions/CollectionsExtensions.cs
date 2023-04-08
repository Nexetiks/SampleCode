using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class CollectionsExtensions
    {
        public static bool TryRemoveRandomElement<T>(this List<T> list, out T randomElement)
        {
            randomElement = default;

            if (list.Count == 0)
            {
                return false;
            }

            int randomNumber = Random.Range(0, list.Count - 1);
            randomElement = list[randomNumber];
            list.Remove(randomElement);
            return true;
        }
    }
}